using Microsoft.AspNetCore.Mvc.RazorPages;

namespace On_Demand_Tutor_UI.Validator
{
    public class TrimmedPageModel : PageModel
    {
        protected void TrimModelStrings<TModel>(TModel model)
        {
            var stringProperties = model.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var property in stringProperties)
            {
                var currentValue = (string)property.GetValue(model);
                if (currentValue != null)
                {
                    var trimmedValue = currentValue.Trim();
                    property.SetValue(model, trimmedValue);
                }
            }
        }
    }
}
