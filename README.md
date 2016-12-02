# bitbot
Tiny Robotic Platform

## Parts
The chassis of the robot is an Olimex [ROBOT-2WD-KIT2](https://www.olimex.com/Products/RobotParts/Chassis/ROBOT-2WD-KIT2/).
On Top is a 5 by 5 Grid of WS2812B strips, which are driven by the [bitkanone](https://github.com/GeraldWodni/bitkanone)-line msp430 port.
Schematics are simple: A MSP430G2554 interfaces with an ULN2803A which pulls the pins of A L293N to control the engines.
Details will follow, until then read the source ;)

## Images
Enough text, some images:
![Wheel-less robot with WS2812B LED-Matrix](/images/2016-12-02_first.jpg?raw=true "Wheel-less robot with WS2812B LED-Matrix")
