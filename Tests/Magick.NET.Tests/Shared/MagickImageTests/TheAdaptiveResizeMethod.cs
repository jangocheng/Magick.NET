﻿// Copyright 2013-2018 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests.Shared
{
    public partial class MagickImageTests
    {
        [TestClass]
        public class TheAdaptiveResizeMethod
        {
            [TestMethod]
            public void ShouldNotEnlargeTheImage()
            {
                using (IMagickImage image = new MagickImage(MagickColors.Black, 512, 1))
                {
                    image.AdaptiveResize(512, 512);

                    Assert.AreEqual(1, image.Height);
                }
            }

            [TestMethod]
            public void ShouldEnlargeTheImageWhenAspectRatioIsIgnored()
            {
                using (IMagickImage image = new MagickImage(MagickColors.Black, 512, 1))
                {
                    var geometry = new MagickGeometry(512, 512)
                    {
                        IgnoreAspectRatio = true,
                    };

                    image.AdaptiveResize(geometry);

                    Assert.AreEqual(512, image.Height);
                }
            }
        }
    }
}
