using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RunCalculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable tblEstTimes = new DataTable();
        DataRow tblRow;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calculate()
        {
            int previousTime = ConvertToSeconds();
            string fiveKTime,
                tenKTime,
                halfTime,
                marathonTime;
            double previousDistance = 0.0;

            switch (lstRecentRace.SelectedIndex)
            {
                case 0: previousDistance = 5000.0;
                    break;
                case 1: previousDistance = 10000.0;
                    break;
                case 2: previousDistance = 21097.5;
                    break;
                case 3: previousDistance = 42195;
                    break;
            }

            fiveKTime = ConvertToTimeFormat(estimateFiveKTime(previousTime, previousDistance));
            tenKTime = ConvertToTimeFormat(estimateTenKTime(previousTime, previousDistance));
            halfTime = ConvertToTimeFormat(estimateHalfTime(previousTime, previousDistance));
            marathonTime = ConvertToTimeFormat(estimateMarathonTime(previousTime, previousDistance));

            lblTemp.Text = "5K time: " + fiveKTime + "<br />" +
                "10K time: " + tenKTime + "<br />" +
                "Half Marathon time: " + halfTime + "<br />" +
                "Marathon time: " + marathonTime;
        }

        protected double riegelPower()
        {
            double riegelPower = 0.0;

            switch (lstWeeklyMileage.SelectedIndex)
            {
                case 0:
                    riegelPower = 1.2;
                    break;
                case 1:
                    riegelPower = 1.15;
                    break;
                case 2:
                    riegelPower = 1.1;
                    break;
                case 3:
                    riegelPower = 1.06;
                    break;
            }

            return riegelPower;
        }

        protected double estimateFiveKTime (int previousTime, double previousDistance)
        {
            double predictedTime = previousTime * Math.Pow((5000 / previousDistance), riegelPower());
            return predictedTime;
        }

        protected double estimateTenKTime (int previousTime, double previousDistance)
        {
            double predictedTime = previousTime * Math.Pow((10000 / previousDistance), riegelPower());
            return predictedTime;
        }

        protected double estimateHalfTime(int previousTime, double previousDistance)
        {
            double predictedTime = previousTime * Math.Pow((21097.5 / previousDistance), riegelPower());
            return predictedTime;
        }

        protected double estimateMarathonTime(int previousTime, double previousDistance)
        {
            double predictedTime = previousTime * Math.Pow((42195 / previousDistance), riegelPower());
            return predictedTime;
        }

        protected string ConvertToTimeFormat(double totalSeconds)
        {
            int convertedSeconds = (int)Math.Round(totalSeconds, 0);
            int hours = convertedSeconds / 3600,
                minutes = (convertedSeconds / 60) % 60,
                seconds = convertedSeconds % 60;

            string strHours, strMinutes, strSeconds;

            if (hours == 0)
            {
                strHours = "";
            }
            else if (hours < 10)
            {
                strHours = "0" + hours.ToString();
            }
            else
            {
                strHours = hours.ToString();
            }

            if (hours == 0 && minutes == 0)
            {
                strMinutes = "";
            }
            else if (hours > 0 && minutes == 0)
            {
                strMinutes = "00";
            }
            else if (minutes < 10)
            {
                strMinutes = "0" + minutes.ToString();
            }
            else
            {
                strMinutes = minutes.ToString();
            }

            if (seconds == 0)
            {
                strSeconds = "00";
            }
            else if (seconds < 10)
            {
                strSeconds = "0" + seconds.ToString();
            }
            else
            {
                strSeconds = seconds.ToString();
            }

            if (hours == 0 && minutes == 0)
            {
                return strSeconds;
            }
            else if (hours == 0)
            {
                return strMinutes + ":" + strSeconds;
            }
            else
            {
                return strHours + ":" + strMinutes + ":" + strSeconds;
            }
        }

        protected int ConvertToSeconds()
        {
            int hourSeconds = 3600 * int.Parse(txtHours.Text);
            int minSeconds = 60 * int.Parse(txtMin.Text);
            int seconds = int.Parse(txtSec.Text);
            return hourSeconds + minSeconds + seconds;
        }

        protected void btnCalcTimes_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}