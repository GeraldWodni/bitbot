\ Use Motor coil-whining for music
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

\ Austrian music notation used: a is english h, okt stands for octave
\ (as oct could be confused with `8 base !` )

compiletoflash


: hz ( u -- )   \ set frequency
    >r 1.000.000 r> um/mod \ SMCLK is 1Mhz, get period by division
    TA1CCR0 ! drop
    TA1CCR0 @ 2/ TA1CCR1 !
    TA1CCR0 @ 2/ TA1CCR2 ! ;
    \ 2 lm    \ don't move, just whine
    \ 2 rm ;  \ both engines (for better volume)

\ we only allow octaves 4-6
0 variable okt
: >okt ( u -- )
    4 - 0 max 2 min okt ! ;

\ octave shift
: ohz okt @ lshift hz ;

: c  262 ohz ;
: c# 277 ohz ;
: d  294 ohz ;
: d# 311 ohz ;
: e  330 ohz ;
: f  349 ohz ;
: f# 370 ohz ;
: g  392 ohz ;
: g# 415 ohz ;
: a  440 ohz ;
: a# 466 ohz ;
: h  494 ohz ;
: _ 0 lm 0 rm ;   \ mute

\ note times
: 1/n ms _ 100 ms ;
: 1/32
    125 1/n ;
: 1/16
    125 1/n ;
: 1/8
    250 1/n ;
: 1/8.
    375 1/n ;
: 1/4
    500 1/n ;
: 1/2
    1000 1/n ;

: music-on
    motor-on    \ enable motors
    _ ;         \ mute

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
