using IconFactory.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconFactory.interfaces {

    public interface IIconFactory {

        /// <summary>Return info required to render an icon</summary>
        /// <param name="code">Icon code</param>
        /// <returns>The icon info object</returns>
        IconDataModel GetIcon(UIIcon code);


    }
}
