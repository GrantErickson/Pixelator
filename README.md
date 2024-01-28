# Pixelator
<img src="/Pixelator/Pixelated/glade.pixelated.png" width="75%" height="75%">

## Impetus
Our team is looking at a low-resolution 'LED Wall' for a backdrop. We wanted to get an idea for what images might look like on this. The idea is to control it via DMX with Art-Net. 

Overall, I am generally surprised by the results. Low resolution images still look decent when enlarged and viewed from a distance. Words are ligible at 10 pixels high. 

This could be improved by using circles for the pixels.

## Using the App
1. Use the command line with a file name as the parameter or a wildcard.
2. Use the library directly.

Note that this uses the internal bitmap handler in DotNet so it will only run on Windows

## The Library

```Bitmap Pixelate(Bitmap source, int targetHeight, double pixelSizePercent = .4 , bool average = true, double brighten = 1.2)```

### Arguments
* `source`: The bitmap to transform
* `targetHeight`: The number of 'pixels' you want your image to have vertically. The horizontal number will be calculated automatically. Note that the resulting image will have the same resolution as the input image.
* `pixelSizePercent`: If each new `pixel` is replacing an area of pixels from the original image, this indicates how large the resulting pixel should be. A 0.4 respresents a 40% of the original area will be the pixel with the rest being black.
* `average`: If true, then the area the pixel represents is averaged. If false, then a single pixel is sampled and the color used. Averaging produces a smoother image.
* `brighten`: The amount to brighten or dim the image. Numbers larger then 1 are brighter. Because much of the image is replaced by black, the image will seem darker. This allows for some compensation.

![glade.pixelated](/Pixelator/Pixelated/glade.pixelated.png)
![glade](/Pixelator/glade.jpg)


![mountains.pixelated](/Pixelator/Pixelated/mountains.pixelated.png)
![mountains](/Pixelator/mountains.jpg)

![rise.pixelated](/Pixelator/Pixelated/rise.pixelated.png)
![rise](/Pixelator/rise.jpg)

![sky.pixelated](/Pixelator/Pixelated/sky.pixelated.png)
![sky](/Pixelator/sky.jpg)

