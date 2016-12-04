\ Introducation program for bitbot on youtube 
\ (c)copyright 2016 by Gerald Wodni <gerald.wodni@gmail.com> 

compiletoflash

\ if you have a plain terminal, just send the files in the same order.
#include basis.fs
#include pwm.fs
#include spi.fs

: init
    init    \ basis-init
    init-pwm \ init motors
    init-spi $20.00.20 leds \ setup WS2812B, and draw some power to keep powerbank running
    ;

#include color-music.fs
#include smile.fs

: movement ( n-left n-right u-duration -- )
    >r
    rm lm
    motor-on
    r> ms
    motor-off ;

: intro
    50 75 1000 movement
    300 ms
    twinkle
    smile ;

: init init
    3000 ms
    key? 0= if
        intro
    then ;
