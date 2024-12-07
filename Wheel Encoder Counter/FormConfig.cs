using System;
using System.Windows.Forms;

namespace Wheel_Encoder_Counter {

  public partial class FormConfig : Form {

    ARC.Config.Sub.PluginV1 _cf;

    public ARC.Config.Sub.PluginV1 GetConfig {
      get => _cf;
    }

    public FormConfig() {

      InitializeComponent();
    }

    public void SetConfig(ARC.Config.Sub.PluginV1 cf) {

      tbEncoderTicks.Text = cf.STORAGE[ConfigTitles.COUNTS_PER_REVOLUTION].ToString();
      tbPivotDiameter.Text = cf.STORAGE[ConfigTitles.PIVOT_DIAMETER].ToString();
      tbWheelDiameter.Text = cf.STORAGE[ConfigTitles.WHEEL_DIAMETER].ToString();

      nudTimerInterval.Value = Convert.ToInt32(cf.STORAGE[ConfigTitles.TIMER_INTERVAL]);

      cbNMS.Checked = Convert.ToBoolean(cf.STORAGE[ConfigTitles.NMS_ENABLED]);

      cbDebug.Checked = Convert.ToBoolean(cf.STORAGE[ConfigTitles.DEBUG]);

      _cf = cf;
    }

    private void btnCancel_Click(object sender, EventArgs e) {

      DialogResult = DialogResult.Cancel;
    }

    private void btnSave_Click(object sender, EventArgs e) {

      try {

        _cf.STORAGE[ConfigTitles.COUNTS_PER_REVOLUTION] = Convert.ToDouble(tbEncoderTicks.Text);
        _cf.STORAGE[ConfigTitles.PIVOT_DIAMETER] = Convert.ToDouble(tbPivotDiameter.Text);
        _cf.STORAGE[ConfigTitles.WHEEL_DIAMETER] = Convert.ToDouble(tbWheelDiameter.Text);

        _cf.STORAGE[ConfigTitles.NMS_ENABLED] = cbNMS.Checked;

        _cf.STORAGE[ConfigTitles.DEBUG] = cbDebug.Checked;

        _cf.STORAGE[ConfigTitles.TIMER_INTERVAL] = nudTimerInterval.Value;

        DialogResult = DialogResult.OK;
      } catch (Exception ex) {

        MessageBox.Show(ex.Message);
      }
    }
  }
}
