# Convolution Kernel Optimized

During this project I was able to investigate and apply the low level software structure required to process digital images efficiently. I realized the importance of bypassing standard slow rendering libraries and instead I utilized unsafe code blocks and locked bits to access the memory directly. This allowed me to manipulate the pixel byte arrays using pointers, achieving a massive improvement in the overall execution speed when applying heavy mathematical convolution matrices directly over the image memory. I achieved a much better performance by modularizing the mathematical processes rather than having all the calculation logic clustered in a single file.

## Code Optimization and Safety

I was able to perform a lot of optimization in the code during the coding phase since I noticed that many memory management operations were critical and could cause the software to directly collapse. During the testing phase I had to modify the code a lot by adding strict boundary validations and mathematical clamping functions to ensure the pointers never accessed restricted memory areas. I also made sure to safely dispose of previous image states to prevent memory leaks when updating the user interface and replacing the active bitmaps.

## Color Space Transformations

The color space transformations were implemented by iterating through every single pixel and mathematically modifying its red, green and blue byte values. I added functionalities to extract independent color channels, invert the rgb values to create a negative effect and adjust the overall luminance to brighten or darken the image. I also built a binarization process based on an intensity threshold and a custom colorization feature that multiplies the gray scale luminance by specific color factors chosen by the user through a color dialogue.

## Advanced Spatial Filtering

For the advanced spatial filtering I applied different convolution kernels to achieve specific visual effects without overloading the system. I programmed low pass filters such as mean filters of various matrix sizes and a Gaussian blur that generates its matrix dynamically using an exponential mathematical formula. For edge detection I implemented high pass filters like Sobel, Prewitt, Laplace and Roberts Cross by calculating the directional gradients across the horizontal and vertical axes and extracting the square root of their combined magnitudes to form the final pixel.

<img width="570" height="227" alt="image" src="https://github.com/user-attachments/assets/f2aa057f-96b6-4b5a-bce1-a9b663e217b6" />



## Non Linear Filtering and Analysis

To handle non linear filtering I implemented a K Nearest Neighbors algorithm that calculates the Euclidean distance between neighboring pixels inside a spatial window. I had to write a custom QuickSort function to order these distances efficiently and average the closest values for superior noise reduction. Finally I included geometric transformations to translate, scale and rotate the image matrix using sine and cosine trigonometric mapping while ensuring the center point offset was corrected. The analysis of the data is completed through dynamic histograms that graph the intensity distribution of the pixel channels directly from the locked memory blocks.
