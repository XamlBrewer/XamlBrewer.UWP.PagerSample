﻿//
// Copyright (c) 2012 Tim Heuer
//
// Licensed under the Microsoft Public License (Ms-PL) (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://opensource.org/licenses/Ms-PL.html
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Callisto.Controls
{
    /// <summary>
    /// FlipViewIndicator is a companion control to be used exclusively with a FlipView control. It serves
    /// the purpose of providing some hinting UI to the user where they are in the navigation of items
    /// within a FlipView. This is similar UI as seen in the Windows Store application when viewing the 
    /// screenshots.
    /// </summary>
    /// <remarks>
    /// The best usage is to be immediately underneath a FlipView and this is easily accomplished by using 
    /// a <see cref="StackPanel"/> as demonstrated below in Usage. When done this way the margins of the 
    /// FlipViewIndicator are set correctly. If using in other means, you may need to adjust margins on
    /// the indicator.
    /// </remarks>
    public sealed class FlipViewIndicator : ListBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlipViewIndicator"/> class.
        /// </summary>
        public FlipViewIndicator()
        {
            this.DefaultStyleKey = typeof(FlipViewIndicator);
        }

        /// <summary>
        /// Gets or sets the flip view.
        /// </summary>
        public FlipView FlipView
        {
            get { return (FlipView)GetValue(FlipViewProperty); }
            set { SetValue(FlipViewProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FlipView"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FlipViewProperty =
            DependencyProperty.Register("FlipView", typeof(FlipView), typeof(FlipViewIndicator), new PropertyMetadata(null, (depobj, args) =>
            {
                FlipViewIndicator fvi = (FlipViewIndicator)depobj;
                FlipView fv = (FlipView)args.NewValue;

                // this is a special case where ItemsSource is set in code
                // and the associated FlipView's ItemsSource may not be available yet
                // if it isn't available, let's listen for SelectionChanged 
                fv.SelectionChanged += (s, e) =>
                {
                    fvi.ItemsSource = fv.ItemsSource;
                };

                fvi.ItemsSource = fv.ItemsSource;

                // create the element binding source
                Binding eb = new Binding();
                eb.Mode = BindingMode.TwoWay;
                eb.Source = fv;
                eb.Path = new PropertyPath("SelectedItem");

                // set the element binding to change selection when the FlipView changes
                fvi.SetBinding(FlipViewIndicator.SelectedItemProperty, eb);
            }));
    }
}
