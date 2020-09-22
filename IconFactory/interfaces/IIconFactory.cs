using IconFactory.Net.data;

namespace IconFactory.Net.interfaces {

    public interface IIconFactory {

        /// <summary>Return info required to render an icon</summary>
        /// <param name="code">Icon code</param>
        /// <returns>The icon info object</returns>
        IconDataModel GetIcon(UIIcon code);


    }
}
