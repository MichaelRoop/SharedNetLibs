using System;
using System.Collections.Generic;
using System.Text;

namespace IconFactory.data {

    public class IconDataModel {

        public UIIcon Code { get; set; } = UIIcon.Exit;

        /// <summary>
        /// Used by OS to store required info to render the image
        /// </summary>
        public object IconSource { get; set; } = new object();

        /// <summary>
        /// For some OS the image is wrapped with padding forcing the size
        /// </summary>
        public object Padding { get; set; } = new object();


        public IconDataModel() {
        }


        public IconDataModel(UIIcon code, object iconSource, object padding) {
            this.Code = code;
            this.IconSource = iconSource;
            this.Padding = padding;
        }


    }
}
