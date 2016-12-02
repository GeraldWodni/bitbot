\ Hardware PWM for controlling the motors
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

: pwm ( -- )
    $02 P2SEL cbis! \ TA1.1 = P2.1
    $02 P2DIR cbis! \ Set as Output
    $2D0 TA1CTL !   \ SMCLK, DIV=8, Up to TA1CCR0
    $0E0 TA1CCTL1 ! \ RESET/SET
    256  TA1CCR0 !  \ max value
     50  TA1CCR1 !  \ pwm value
    ;

: p ( n -- )
    TA1CCR1 ! ;
