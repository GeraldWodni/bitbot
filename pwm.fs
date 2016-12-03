\ Hardware PWM for controlling the motors
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

\ change pwm output pin
: p2-sel ( x-set x-clr n -- )
    0< if swap then
    2dup P2DIR cbic! P2DIR cbis!
         P2SEL cbic! P2SEL cbis! ;

\ set pwm values, for left/right motor [-256, 256]
: lm ( n -- )
    >r $02 $04 r@ p2-sel
    r> abs TA1CCR1 ! ;

: rm ( n -- )
    >r $10 $20 r@ p2-sel
    r> abs TA1CCR2 ! ;

\ en/disable drivers
: motor-on
    $09 p2out cbic! ;

: motor-off
    $09 p2out cbis! ;

: init-pwm ( -- )
    $12 P2SEL c! \ TA1.1 = P2.1
    $09 P2DIR cbis! \ set driver pins
    $2D0 TA1CTL !   \ SMCLK, DIV=8, Up to TA1CCR0
    $0E0 TA1CCTL1 ! \ RESET/SET
    $0E0 TA1CCTL2 ! \ RESET/SET
    256  TA1CCR0 !  \ max value
    0 lm
    0 rm
    motor-off ;

\ debug registers (TODO: delete)
: pwm.
    ." P2OUT:    " P2OUT c@ hex. cr
    ." P2DIR:    " P2DIR c@ hex. cr
    ." P2SEL:    " P2SEL c@ hex. cr
    ." TA1CTL:   " TA1CTL @ hex. cr
    ." TA0CCR0:  " TA0CCR0 @ hex. cr
    ." TA0CCR1:  " TA0CCR1 @ hex. cr
    ." TA1CCTL1: " TA1CCTL1 @ hex. cr ;

