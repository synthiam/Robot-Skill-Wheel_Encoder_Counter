using System;
using System.Windows.Forms;
using ARC;
using ARC.Config.Sub;

namespace Wheel_Encoder_Counter {

  public partial class FormMain : ARC.UCForms.FormPluginMaster {

    readonly string _CMD_AUTO_REFRESH_START = "AutoRefreshStart";
    readonly string _CMD_AUTO_REFRESH_STOP = "AutoRefreshStop";
    readonly string _CMD_GET_VALUES = "GetValues";
    readonly string _CMD_GET_VALUES_AND_RESET = "GetValuesAndReset";
    readonly string _CMD_RESET_VALUES = "ResetValues";
    readonly string _CMD_DEBUG_ON = "DebugOn";
    readonly string _CMD_DEBUG_OFF = "DebugOff";

    System.Timers.Timer _timer;
    bool _isClosing = false;

    public FormMain() {

      InitializeComponent();

      ConfigButton = false;

      _timer = new System.Timers.Timer();
      _timer.Interval = 1000;
      _timer.Elapsed += _timer_Elapsed;
    }

    public override void SetConfiguration(PluginV1 cf) {

      ARC.Scripting.VariableManager.SetVariable("$LeftWheelCount", 0);
      ARC.Scripting.VariableManager.SetVariable("$RightWheelCount", 0);

      base.SetConfiguration(cf);
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {

      _isClosing = true;

      _timer.Stop();
      _timer.Dispose();
      _timer = null;
    }

    private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {

      if (_isClosing)
        return;

      readValues();
    }

    public override object[] GetSupportedControlCommands() {

      return new string[] {
        Common.Quote(_CMD_AUTO_REFRESH_START),
        Common.Quote(_CMD_AUTO_REFRESH_STOP),
        Common.Quote(_CMD_GET_VALUES),
        Common.Quote(_CMD_GET_VALUES_AND_RESET),
        Common.Quote(_CMD_RESET_VALUES),
        Common.Quote(_CMD_DEBUG_ON),
        Common.Quote(_CMD_DEBUG_OFF)
      };
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      if (windowCommand.Equals(_CMD_AUTO_REFRESH_START, StringComparison.InvariantCultureIgnoreCase)) {

        _timer.Start();
        Invokers.SetChecked(cbUpdate, true);
      } else if (windowCommand.Equals(_CMD_AUTO_REFRESH_STOP, StringComparison.InvariantCultureIgnoreCase)) {

        _timer.Stop();
        Invokers.SetChecked(cbUpdate, false);
      } else if (windowCommand.Equals(_CMD_GET_VALUES, StringComparison.InvariantCultureIgnoreCase)) {

        readValues();

      } else if (windowCommand.Equals(_CMD_GET_VALUES_AND_RESET, StringComparison.InvariantCultureIgnoreCase)) {

        readValuesAndReset();
      } else if (windowCommand.Equals(_CMD_RESET_VALUES, StringComparison.InvariantCultureIgnoreCase)) {

        ResetValues();
      } else if (windowCommand.Equals(_CMD_DEBUG_OFF, StringComparison.InvariantCultureIgnoreCase)) {

        Invokers.SetChecked(cbDebug, false);
      } else if (windowCommand.Equals(_CMD_DEBUG_ON, StringComparison.InvariantCultureIgnoreCase)) {

        Invokers.SetChecked(cbDebug, true);
      } else {

        base.SendCommand(windowCommand, values);
      }
    }

    void readValues() {

      try {

        if (!EZBManager.EZBs[0].Firmware.IsCapabilitySupported(EZ_B.Firmware.XMLFirmwareSimulator.CAP_WHEEL_ENCODER_RESPONSE_V1))
          throw new Exception("The connected device does not support the required capability to count Wheel Encoding");

        var response = EZBManager.EZBs[0].SendCommandData(4, 0x00, 0x00);

        UInt16 leftWheel = BitConverter.ToUInt16(response, 0);
        UInt16 rightWheel = BitConverter.ToUInt16(response, 2);

        ARC.Scripting.VariableManager.SetVariable("$LeftWheelCount", leftWheel);
        ARC.Scripting.VariableManager.SetVariable("$RightWheelCount", rightWheel);

        if (Invokers.GetCheckedValue(cbDebug))
          Invokers.SetAppendText(textBox1, true, "Left Wheel: {0}, Right wheel: {1}", leftWheel, rightWheel);
      } catch (Exception ex) {

        Invokers.SetAppendText(textBox1, true, ex.ToString());
      }
    }

    void readValuesAndReset() {

      try {

        if (!EZBManager.EZBs[0].Firmware.IsCapabilitySupported(EZ_B.Firmware.XMLFirmwareSimulator.CAP_WHEEL_ENCODER_RESPONSE_V1))
          throw new Exception("The connected device does not support the required capability to count Wheel Encoding");

        var response = EZBManager.EZBs[0].SendCommandData(4, 0x00, 0x01);

        UInt16 leftWheel = BitConverter.ToUInt16(response, 0);
        UInt16 rightWheel = BitConverter.ToUInt16(response, 2);

        ARC.Scripting.VariableManager.SetVariable("$LeftWheelCount", leftWheel);
        ARC.Scripting.VariableManager.SetVariable("$RightWheelCount", rightWheel);

        if (Invokers.GetCheckedValue(cbDebug))
          Invokers.SetAppendText(textBox1, true, "Left Wheel: {0}, Right wheel: {1}", leftWheel, rightWheel);
      } catch (Exception ex) {

        Invokers.SetAppendText(textBox1, true, ex.ToString());
      }
    }

    void ResetValues() {

      try {

        if (!EZBManager.EZBs[0].Firmware.IsCapabilitySupported(EZ_B.Firmware.XMLFirmwareSimulator.CAP_WHEEL_ENCODER_RESPONSE_V1))
          throw new Exception("The connected device does not support the required capability to count Wheel Encoding");

        EZBManager.EZBs[0].SendCommandData(0, 0x00, 0x02);

        if (Invokers.GetCheckedValue(cbDebug))
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

    private void cbUpdate_CheckedChanged(object sender, EventArgs e) {

      if (cbUpdate.Checked)
        _timer.Start();
      else
        _timer.Stop();
    }
  }
}
