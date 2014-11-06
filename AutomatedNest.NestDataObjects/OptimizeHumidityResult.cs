using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatedNest.NestDataObjects
{
    public class OptimizeHumidityResult
    {
        public enum OperationResultOptions
        {
            ERROR = -1,
            NO_CHANGE_NEEDED = 1,
            CHANGE_SUCCEEDED = 2,
        }

        public OperationResultOptions OperationResult
        {
            get;
            set;
        }

        public int OldTargetHumidity
        {
            get;
            set;
        }

        public int NewTargetHumidity
        {
            get;
            set;
        }

        public int LowForecastTemperature
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public string OperationStatus
        {
            get
            {
                if (OperationResult == OperationResultOptions.ERROR)
                    return "Operation Failed: " + ErrorMessage;
                else if (OperationResult == OperationResultOptions.CHANGE_SUCCEEDED)
                    return "Lowest forecast temperature is " + LowForecastTemperature+ ".  Target humidity successfuly changed from " + OldTargetHumidity + "% to " + NewTargetHumidity + "%";
                else if (OperationResult == OperationResultOptions.NO_CHANGE_NEEDED)
                    return "Lowest forecast temperature is " + LowForecastTemperature + ".  Target humidity remains set at: " + OldTargetHumidity;

                return "Error in determining status";
            }
        }
    }
}
