using System;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CityApp.Models
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        private const string emailRegex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            base.OnAttachedTo(bindable);
        }
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = false;
            isValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = isValid ? Colors.Black  : Colors.Red;

        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
            base.OnDetachingFrom(bindable);
        }
    }

}

