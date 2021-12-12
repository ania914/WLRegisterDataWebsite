using DevExpress.ExpressApp.Actions;
using System;

namespace WLRegisterDataWebsite.Module.Extensions
{
    public static class SingleChoiceActionExtensions
    {
        public static void FillWithEnumValues(this SingleChoiceAction singleChoiceAction, Type enumType)
        {
            if (!enumType.IsEnum) return;

            foreach(var item in Enum.GetValues(enumType))
            {
                singleChoiceAction.Items.Add(new ChoiceActionItem(item.ToString(), item));
            }
        }
    }
}
