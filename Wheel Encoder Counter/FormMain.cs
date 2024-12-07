using System;
using System.Windows.Forms;
using ARC;
using ARC.Config.Sub;

namespace Wheel_Encoder_Counter {

  public partial class FormMain : ARC.UCForms.FormPluginMaster {

    readonly string _CMD_GET_VALUES = "GetValues";
    readonly string _CMD_GET_VALUES_AND_RESET = "GetValuesAndReset";
    readonly string _CMD_RESET_VALUES = "ResetValues";

    ARC.TimerSmart _timer;
    bool _isClosing = false;

    int _lastLeftCount = 0;
    int _lastRightCount = 0;
    double _xPos = 0;
    double _yPos = 0;
    double _currentAngle = 0;

    double _countsPerRev = 508.8;              // encoder ticks per wheel revolution
    double _wheelDiameter = 72;                // wheel diameter
    double _pivotDiam = 235;                   // pivot diameter = distance between centers of wheel treads 

    public FormMain() {

      InitializeComponent();

      ConfigButton = true;

      _timer = new TimerSmart();
      _timer.Interval = 1000;
      _timer.Elapsed += _timer_Elapsed;
    }

    public override void SetConfiguration(PluginV1 cf) {

      ARC.Scripting.VariableManager.SetVariable("$LeftWheelCount", 0);
      ARC.Scripting.VariableManager.SetVariable("$RightWheelCount", 0);

      cf.STORAGE.AddIfNotExist(ConfigTitles.DEBUG, false);

      cf.STORAGE.AddIfNotExist(ConfigTitles.NMS_ENABLED, true);

      cf.STORAGE.AddIfNotExist(ConfigTitles.TIMER_INTERVAL, 100);

      cf.STORAGE.AddIfNotExist(ConfigTitles.COUNTS_PER_REVOLUTION, 508.8);
      cf.STORAGE.AddIfNotExist(ConfigTitles.WHEEL_DIAMETER, 72);
      cf.STORAGE.AddIfNotExist(ConfigTitles.PIVOT_DIAMETER, 235);

      _countsPerRev = Convert.ToDouble(cf.STORAGE[ConfigTitles.COUNTS_PER_REVOLUTION]);
      _wheelDiameter = Convert.ToDouble(cf.STORAGE[ConfigTitles.WHEEL_DIAMETER]);
      _pivotDiam = Convert.ToDouble(cf.STORAGE[ConfigTitles.PIVOT_DIAMETER]);

      if (!_timer.IsTimerActive)
        _timer.Start();

      EZBManager.MovementManager.OnMovement2 += MovementManager_OnMovement2;

      base.SetConfiguration(cf);
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {

      EZBManager.MovementManager.OnMovement2 -= MovementManager_OnMovement2;

      _isClosing = true;

      _timer.Stop();
      _timer.Dispose();
      _timer = null;
    }

    public override void ConfigPressed() {

      _timer.Stop();

      using (var f = new FormConfig()) {

        f.SetConfig(_cf);

        if (f.ShowDialog() == DialogResult.OK) {

          SetConfiguration(f.GetConfig);
        }
      }
    }

    private void MovementManager_OnMovement2(MovementManager.MovementDirectionEnum direction, byte speedLeft, byte speedRight) {

      const int LEFT_FORWARD  = 0b00000000; // 0x00
      const int LEFT_REVERSE  = 0b00000001; // 0x01
      const int RIGHT_FORWARD = 0b00000000; // 0x00
      const int RIGHT_REVERSE = 0b00000010; // 0x02

      switch (direction) {
        case MovementManager.MovementDirectionEnum.Forward:
          EZBManager.EZBs[0].SendCommandData(0, 0x00, 0x03, (LEFT_FORWARD + RIGHT_FORWARD));
          break;
        case MovementManager.MovementDirectionEnum.Reverse:
          EZBManager.EZBs[0].SendCommandData(0, 0x00, 0x03, (LEFT_REVERSE + RIGHT_REVERSE));
          break;
        case MovementManager.MovementDirectionEnum.Right:
          EZBManager.EZBs[0].SendCommandData(0, 0x00, 0x03, (LEFT_FORWARD + RIGHT_REVERSE));
          break;
        case MovementManager.MovementDirectionEnum.Left:
          EZBManager.EZBs[0].SendCommandData(0, 0x00, 0x03, (LEFT_REVERSE + RIGHT_FORWARD));
          break;
      }
    }

    private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {

      if (_isClosing)
        return;

      readValues();
    }

    public override object[] GetSupportedControlCommands() {

      return new string[] {
        Common.Quote(_CMD_GET_VALUES),
        Common.Quote(_CMD_GET_VALUES_AND_RESET),
        Common.Quote(_CMD_RESET_VALUES),
      };
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      if (windowCommand.Equals(_CMD_GET_VALUES, StringComparison.InvariantCultureIgnoreCase)) {

        readValues();

      } else if (windowCommand.Equals(_CMD_GET_VALUES_AND_RESET, StringComparison.InvariantCultureIgnoreCase)) {

        readValuesAndReset();
      } else if (windowCommand.Equals(_CMD_RESET_VALUES, StringComparison.InvariantCultureIgnoreCase)) {

        ResetValues();
      } else {

        base.SendCommand(windowCommand, values);
      }
    }

    void readValues() {

      try {

        if (!EZBManager.PrimaryEZB.IsConnected)
          return;

        if (!EZBManager.EZBs[0].Firmware.IsCapabilitySupported(EZ_B.Firmware.XMLFirmwareSimulator.CAP_WHEEL_ENCODER_RESPONSE_V1))
          throw new Exception("The connected device does not support the required capability to count Wheel Encoding");

        var response = EZBManager.EZBs[0].SendCommandData(4, 0x00, 0x00);

        UInt16 leftWheel = BitConverter.ToUInt16(response, 0);
        UInt16 rightWheel = BitConverter.ToUInt16(response, 2);

        ARC.Scripting.VariableManager.SetVariable("$LeftWheelCount", leftWheel);
        ARC.Scripting.VariableManager.SetVariable("$RightWheelCount", rightWheel);

        if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.DEBUG]))
          Invokers.SetAppendText(textBox1, true, "Left Wheel: {0}, Right wheel: {1}", leftWheel, rightWheel);

        if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.NMS_ENABLED])) {

          double wheelRadius = _wheelDiameter / 2;   // wheel Radius
          double wheelCirc = Math.PI * wheelRadius; // wheel circumference
          double pivotCirc = Math.PI * _pivotDiam;   // pivot circumference

          var elapsedLeft = leftWheel - _lastLeftCount;
          var elapsedRight = rightWheel - _lastRightCount;

          // These are to see if the uint16 has wrapped (moving backward from an encoder position of 0 or moving past 65335)
          // REQUIRES TESTING
          if (elapsedLeft > 30000)
            elapsedLeft = UInt16.MaxValue - elapsedLeft;
          else if (elapsedLeft < -30000)
            elapsedLeft = UInt16.MaxValue + elapsedLeft;

          if (elapsedRight > 30000)
            elapsedRight = UInt16.MaxValue - elapsedRight;
          else if (elapsedRight < -30000)
            elapsedRight = UInt16.MaxValue + elapsedRight;

          // https://hackaday.io/project/165046-autonomous-navigation

          // This is the distance calculation suggested from the opensource spec
          // https://www.irobotweb.com/~/media/MainSite/PDFs/About/STEM/Create/iRobot_Roomba_600_Open_Interface_Spec.pdf
          // we should try these 
          var Dl2 = elapsedLeft * (Math.PI * _wheelDiameter / _countsPerRev);
          var Dr2 = elapsedRight * (Math.PI * _wheelDiameter / _countsPerRev);
          var radians = (Dr2 - Dl2) / _pivotDiam;
          var degrees = radians * (180  / Math.PI);

          var Dl = Math.PI * _wheelDiameter * (elapsedLeft / _countsPerRev);
          var Dr = Math.PI * _wheelDiameter * (elapsedRight / _countsPerRev);
          var Dc = (Dl + Dr) / 2;

          var a = (180 / Math.PI) * (Dl - Dr) / _pivotDiam;

          _currentAngle = (_currentAngle - a) % 360;

          if (_currentAngle < 0)
            _currentAngle += 360;

          // https://robotics.stackexchange.com/questions/7062/create2-angle-packet-id-20
          // https://robotics.stackexchange.com/questions/7229/irobot-create-2-encoder-counts

          //var angle = ( ((sensorData.RightEncoderCounts / countsPerRev) * wheelDiameter * Math.PI) - ((sensorData.LeftEncoderCounts / countsPerRev) * wheelDiameter * Math.PI) ) / pivotDiam;

          //angle = (angle * (180 / Math.PI)) % 360;

          //if (angle < 0)
          //  angle += 360;

          _xPos += EZ_B.Functions.DegX2(_currentAngle, Dc);
          _yPos += EZ_B.Functions.DegY2(_currentAngle, Dc);

          //            ARC.EZBManager.Log($"{angle} x {_totalAngle}");

          ARC.MessagingService.Navigation2DV1.Messenger.UpdateLocation(
              (float)_xPos / 10,
              (float)_yPos / 10,
              255,
              (float)_currentAngle);

          _lastLeftCount = leftWheel;
          _lastRightCount = rightWheel;
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(textBox1, true, ex.ToString());
      }
    }

    void readValuesAndReset() {

      try {

        if (!EZBManager.PrimaryEZB.IsConnected)
          return;

        if (!EZBManager.EZBs[0].Firmware.IsCapabilitySupported(EZ_B.Firmware.XMLFirmwareSimulator.CAP_WHEEL_ENCODER_RESPONSE_V1))
          throw new Exception("The connected device does not support the required capability to count Wheel Encoding");

        var response = EZBManager.EZBs[0].SendCommandData(4, 0x00, 0x01);

        UInt16 leftWheel = BitConverter.ToUInt16(response, 0);
        UInt16 rightWheel = BitConverter.ToUInt16(response, 2);

        ARC.Scripting.VariableManager.SetVariable("$LeftWheelCount", leftWheel);
        ARC.Scripting.VariableManager.SetVariable("$RightWheelCount", rightWheel);

        if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.DEBUG]))
          Invokers.SetAppendText(textBox1, true, "Left Wheel: {0}, Right wheel: {1}", leftWheel, rightWheel);
      } catch (Exception ex) {

        Invokers.SetAppendText(textBox1, true, ex.ToString());
      }
    }

    void ResetValues() {

      try {

        if (!EZBManager.PrimaryEZB.IsConnected)
          return;

        if (!EZBManager.EZBs[0].Firmware.IsCapabilitySupported(EZ_B.Firmware.XMLFirmwareSimulator.CAP_WHEEL_ENCODER_RESPONSE_V1))
          throw new Exception("The connected device does not support the required capability to count Wheel Encoding");

        EZBManager.EZBs[0].SendCommandData(0, 0x00, 0x02);

        if (Convert.ToBoolean(_cf.STORAGE[ConfigTitles.DEBUG]))
          Invokers.SetAppendText(textBox1, true, "Resetting wheel values");
      } catch (Exception ex) {

        Invokers.SetAppendText(textBox1, true, ex.ToString());
      }
    }

    private void button1_Click(object sender, EventArgs e) {

      readValues();
    }

    private void button2_Click(object sender, EventArgs e) {

      readValuesAndReset();
    }

    private void btnResetValues_Click(object sender, EventArgs e) {

      ResetValues();
    }
  }
}
