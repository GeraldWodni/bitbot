\ Display a smiley face
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

\ set pixel yellow
: yellow ( px -- )
    >r $20.20.00 r> rgb-px! ;
    
: smile ( -- )
    $00.00.00 buffer! \ clear display
    1 yellow 8 yellow \ left-eye
    3 yellow 6 yellow \ right-eye
    3 yellow \ right-eye
    19 yellow   \ mouth-left
    15 yellow   \ mouth-right
    24 21 do    \ mouth-low
        i yellow
    loop flush ;
        
