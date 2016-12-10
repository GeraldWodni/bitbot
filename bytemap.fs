\ display bitmaps using turtle graphics
\ (c)copyright 2016 by Gerald Wodni <gerald.wodni@gmail.com> 

compiletoflash

: map ( c-addr len -- )
    bounds do
        i c@ \ get current pattern
        8 0 do
            dup $80 and if dot then
            1 tx +! \ increment x
            1 lshift
        loop drop
        -8 tx +! \ revert to start x
         1 ty +! \ increment y size
    loop ;

create circles  $10 c, $80 c, $00 c, $08 c, $40 c,
                $20 c, $00 c, $88 c, $00 c, $20 c,
                $40 c, $08 c, $00 c, $80 c, $10 c,

: circle ( n -- )
    5 * circles + 5 map flush ;

: turn ( n -- )
    0 0 buffer!
    0 do
        0 0 pos $00.1f.00 color
        3 0 do i circle loop
        0 0 pos $00.3f.00 color
        i 3 mod circle 100 ms
    loop ;
