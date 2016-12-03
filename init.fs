\ "boot" file
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

: init
    init    \ basis-init
    init-pwm \ init motors
    $20.00.20 leds \ setup WS2812B, and draw some power to keep powerbank running
    ;

cornerstone cold

: init
    init
    init-spi $20.20.20 leds \ setup WS2812B, and draw some power to keep powerbank running
    twinkle
    $20.00.20 leds \ setup WS2812B, and draw some power to keep powerbank running
    0 led
    ;

init
