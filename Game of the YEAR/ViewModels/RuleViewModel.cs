using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_of_the_YEAR.ViewModels
{
    class RuleViewModel : Base.BaseViewModel
    {
        public ICommand OkBtn { get; set; }

        public string Rules { get; set; } =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut blandit tortor massa. Fusce vel laoreet nisi, in dignissim risus. Sed a massa nec mi varius elementum. Nullam feugiat convallis sapien gravida pharetra. In eget nunc quam. Curabitur est erat, malesuada eget mauris at, venenatis congue augue. Suspendisse aliquet, tortor ac suscipit viverra, libero purus blandit elit, sit amet rhoncus purus magna non ligula. Vivamus vulputate tortor at erat ultricies aliquam. Nam in dolor mattis, luctus mauris et, posuere ipsum. Morbi in urna leo.Donec condimentum enim nec diam dictum dapibus.Vestibulum at quam eget augue accumsan laoreet.Aenean condimentum nunc nec justo ornare, sed efficitur sem sagittis.Nullam id malesuada sem, nec tempus arcu. Vestibulum metus est, pellentesque quis magna vitae, placerat finibus enim.Nam eleifend, dui eget aliquam vestibulum, lorem massa commodo turpis, molestie iaculis diam mi quis turpis. Donec vehicula, lorem ut fermentum tempor, turpis arcu pharetra erat, eget pretium odio dolor eget magna. Duis nec est id enim eleifend placerat.Donec quis sodales massa. Duis mauris est, vestibulum quis felis quis, vestibulum posuere nisl.Morbi sit amet elit lobortis, tincidunt metus eget, efficitur nibh. Sed commodo elementum tellus vel eleifend. Phasellus eleifend ex vitae urna vehicula venenatis at a enim. Etiam vestibulum egestas lorem, quis laoreet nisi iaculis sed.";


        public RuleViewModel()
        {

        }

        public void GoToStartGamePage()
        {
            Page page = new Views.StartGamePage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).Main.Content = page;
        }
    }
}
