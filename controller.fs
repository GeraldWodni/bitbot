\ Read NES-Controller (serial register with latch)
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash
\ Pin/Function  NES-Controller-wire     Resistor for current limitation
\ +5V           white
\ P1.3 CLOCK    red                     330R
\ P1.4 DATA-IN  yellow                  4k7
\ P1.5 LATCH    orange                  330R
\ GND           brown
$08 P1OUT 2constant CLK
$10 P1IN  2constant DIN
$20 P1OUT 2constant LATCH

\ nes> returns mask of currently pressed buttons
\ # Buttons   Value
\ 0 A         $01
\ 1 B         $02
\ 2 Select    $04
\ 3 Start     $08
\ 4 North     $10
\ 5 South     $20
\ 6 West      $40
\ 7 East      $80
: nes> ( -- x-buttons )
    LATCH cbis!     \ latch buttons
    20 us
    LATCH cbic!
    0 8 0 do
        10 us
        2/
        DIN c@ and 0<> if \ button pressed?
            $80 or
        then
        CLK cbis!   \ clk impulse
        10 us
        CLK cbic!
    loop $FF xor $FF and ;
