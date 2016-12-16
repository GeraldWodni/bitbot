\ Visualize nes-controller-status on display
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

: red-on-off ( f-flag n-index -- )
    >r if
        $3F.00.00
    else
        $10.00.00
    then r> rgb-px! ;

: white-on-off ( f-flag n-index -- )
    >r if
        $3F.3F.3F
    else
        $10.10.10
    then r> rgb-px! ;

: show-nes ( -- )
    begin
        $00.00.20 buffer!
        nes>
        dup $80 and  7 white-on-off \ East
        dup $40 and  9 white-on-off \ West
        dup $20 and 11 white-on-off \ South
        dup $10 and  1 white-on-off \ North
        dup $04 and 20 white-on-off \ Select
        dup $08 and 21 white-on-off \ Start
        dup $02 and 23 red-on-off \ B
        dup $01 and 24 red-on-off \ A
        drop
        flush
    key?
    until ;

show-nes
