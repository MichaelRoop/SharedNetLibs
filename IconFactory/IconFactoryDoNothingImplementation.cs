using IconFactory.Net.data;
using IconFactory.Net.interfaces;

namespace IconFactory.Net {

    public class IconFactoryDoNothingImplementation : IIconFactory {

        public IconDataModel GetIcon(UIIcon code) {
            return new IconDataModel() {
                Code = code,
                IconSource = string.Empty,
                Padding = string.Empty,
            };
        }

    }
}
