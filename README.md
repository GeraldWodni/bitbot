# bitbot
(c)copyright 2016 by Gerald Wodni
Tiny Robotic Platform

## Parts
The chassis of the robot is an Olimex [ROBOT-2WD-KIT2](https://www.olimex.com/Products/RobotParts/Chassis/ROBOT-2WD-KIT2/).
On Top is a 5 by 5 Grid of WS2812B strips, which are driven by the [bitkanone](https://github.com/GeraldWodni/bitkanone)-line msp430 port.
Schematics are simple: A MSP430G2554 interfaces with an ULN2803A which pulls the pins of A L293N to control the engines.
Details will follow, until then read the source ;)


## Images
Enough text, some images:
![Wheel-less robot with WS2812B LED-Matrix](/images/2016-12-02_first.jpg?raw=true "Wheel-less robot with WS2812B LED-Matrix")


## Words
Motor
```forth
motor-on        ( -- )                  Enable  Bridge-Drivers
motor-off       ( -- )                  Disable --//--
lm              ( n -- )                Set speed for left  engine where n [-256, 256]
rm              ( n -- )                Set speed for right engine where n [-256, 256]

System
```forth



## Wiring

### Serial
Uart-RX P1.1 RXD
Uart-TX P1.1 TXD

### Motor
Left-EN   P2.0
Left-FWD  P2.1 TA1.1
Left-BWD  P2.2 TA1.1
Right-EN  P2.3
Right-FWD P2.4 TA1.2
Right-BWD P2.5 TA1.2

### WS2812B
Data P1.7 UCB0SIMO

### Debug
Red-Led P2.6 TA0.1
Reset RST (pulled up with 4k7, push-button against GND)
