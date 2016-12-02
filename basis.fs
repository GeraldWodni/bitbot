\ Basisdefintions: registers & some utils
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

\ Ports

$20 constant P1IN
$21 constant P1OUT
$22 constant P1DIR
\ $23 constant P1IFG
\ $24 constant P1IES
\ $25 constant P1IE
$26 constant P1SEL
$27 constant P1REN
$41 constant P1SEL2

$28 constant P2IN
$29 constant P2OUT
$2A constant P2DIR
\ $2B constant P2IFG
\ $2C constant P2IES
\ $2D constant P2IE
$2E constant P2SEL
$2F constant P2REN
$42 constant P2SEL2

\ SLAVE UART registers
\ $68 constant UCB0CTL0
\ $69 constant UCB0CTL1
\ $6A constant UCB0BR0
\ $6B constant UCB0BR1
\ $6E constant UCB0RXBUF
\ $6F constant UCB0TXBUF

\ Timer A0_3 & A1_3
$160 constant TA0CTL
$170 constant TA0R 
$162 constant TA0CCTL0 
$172 constant TA0CCR0 
$164 constant TA0CCTL1 
$174 constant TA0CCR1 
$166 constant TA0CCTL2 
$176 constant TA0CCR2 

$180 constant TA1CTL
$190 constant TA1R 
$182 constant TA1CCTL0 
$192 constant TA1CCR0 
$184 constant TA1CCTL1 
$194 constant TA1CCR1 
$186 constant TA1CCTL2 
$196 constant TA1CCR2 

: bounds ( c-addr n -- c-addr-end c-addr-start )
    over + swap ;

: within ( test low high -- f )
    over - >r - r> u< ;

: cornerstone ( Name ) ( -- )
    <builds begin here $1FF and while 0 , repeat
    does>   begin dup  $1FF and while 1+  repeat eraseflashfrom ;

: >number ( n -- c-addr n-len )
    0 <# #S #> ;

: >u.n ( u n -- ) >r 0 <# r> 0 do # loop #> ;

\ print number right-aligned
: .r ( u n -- )
    >r >number r> over - 0 max spaces type ;
: .s ( -- )
    ." <" depth 0 .r ." > " depth 1+ 1 ?do depth i - pick . loop ;

: u.n ( u n -- ) >u.n type ;
: u.4 ( u -- ) 4 u.n ;
: u.2 ( u -- ) 2 u.n ;

\ turn red led on
: r
    $10 P2DIR cbis!
    $10 P2OUT cbis! ;

\ turn red led off
: o
    $10 P2OUT cbic! ;

\ turn left engine on (fwd)
: lon
    $20 P1DIR cbis!
    $20 P1OUT cbis! ;

\ turn left engine off (fwd)
: loff
    $20 P1OUT cbic! ;

cornerstone cold
