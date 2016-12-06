\ "boot" file
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

: init
    init    \ basis-init
    init-pwm \ init motors
    init-spi $10.00.10 leds \ setup WS2812B, and draw some power to keep powerbank running
    ;

cornerstone cold
