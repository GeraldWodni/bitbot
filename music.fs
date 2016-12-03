\ Use Motor coil-whining for music
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash


: hz ( u -- )    \ set frequency
    >r 1.000.000 r> um/mod \ SMCLK is 1Mhz, get period by division
    TA1CCR0 ! ;

: c  262 hz ;
: c# 277 hz ;
: d  294 hz ;
: d# 311 hz ;
: e  330 hz ;
: f  349 hz ;
: f# 370 hz ;
: g  392 hz ;
: g# 415 hz ;
: a  440 hz ;
: a# 466 hz ;
: h  494 hz ;
: _    1 hz ;   \ "mute"

\ note times
: 1/8
    250 ms _ 100 ms ;
: 1/4
    500 ms _ 100 ms ;

: music-on
    motor-on    \ enable motors
    1 lm        \ don't move, just whine
    _ ;         \ "mute"

\ twinkle twinkle
: tw-tw
    c 1/8
    c 1/8
    g 1/8
    g 1/8
    a 1/8
    a 1/8
    g 1/4

    f 1/8
    f 1/8
    e 1/8
    e 1/8
    d 1/8
    d 1/8
    c 1/4 ;

: tw-up
    g 1/8
    g 1/8
    f 1/8
    f 1/8
    e 1/8
    e 1/8
    d 1/4 ;

: twinkle
    music-on
    tw-tw
    tw-up
    tw-up
    tw-tw
    motor-off ;

twinkle
