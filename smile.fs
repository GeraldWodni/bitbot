\ Display a smiley face
\ (c)copyright 2016 by Gerald Wodni<gerald.wodni@gmail.com>

compiletoflash

: smile ( -- )
    0 tox ! 0 toy !
    $00.00.00 buffer!  \ clear display
    $20.20.00 color     \ nice yellow
    1 0 pos dot \ left-eye
    3 0 pos dot \ right-eye

    2 2 pos dot \ nose

    0 3 pos dot \ mouth-left
    4 3 pos dot \ mouth-right
    1 4 pos
    3 4 line    \ mouth-low
    flush ;
