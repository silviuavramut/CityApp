using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Models
{
    public class NumberValidationBehavior : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            base.OnAttachedTo(bindable);
        }
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            bool isValid = int.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
