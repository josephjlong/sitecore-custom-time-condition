using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;

namespace SitecoreDemo.Foundation.CustomCondtions.Condition
{
    public class TimeOfDayCondition<T> : OperatorCondition<T> where T : RuleContext
    {

        public string TimeField { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");

            ConditionOperator conditionOperator = base.GetOperator();

            TimeSpan? timeToCompare = ConvertTime(TimeField);

            if (!timeToCompare.HasValue)
            {
                return false;
            }
                

            return TimeSpanComparer(DateTime.Now.TimeOfDay, timeToCompare.Value, conditionOperator);

        }


        private TimeSpan? ConvertTime(string timeToConvert)
        {
            DateTime time;
            if (!DateTime.TryParse(timeToConvert, out time))
                return null;

            return time.TimeOfDay;

        }


        private bool TimeSpanComparer(TimeSpan timeSpan1, TimeSpan timeSpan2, ConditionOperator conditionOperator)
        {

            switch (conditionOperator)
            {
                case ConditionOperator.Equal:
                    return timeSpan1.Equals(timeSpan2);
                case ConditionOperator.LessThan:
                    return timeSpan1 < timeSpan2;
                case ConditionOperator.LessThanOrEqual:
                    return timeSpan1 <= timeSpan2;
                case ConditionOperator.GreaterThan:
                    return timeSpan1 > timeSpan2;
                case ConditionOperator.GreaterThanOrEqual:
                    return timeSpan1 >= timeSpan2;
                case ConditionOperator.NotEqual:
                    return !timeSpan1.Equals(timeSpan2);
                default:
                    return false;
            }

        }

    }
}
