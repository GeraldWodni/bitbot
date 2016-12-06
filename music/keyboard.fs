compiletoflash
: keyboard
    music-on
    begin
        false
        key case
            \ white keys
            [char] y of c endof
            [char] x of d endof
            [char] c of e endof
            [char] v of f endof
            [char] b of g endof
            [char] n of a endof
            [char] m of h endof

            \ black keys
            [char] s of c# endof
            [char] d of d# endof
            [char] g of f# endof
            [char] h of g# endof
            [char] j of a# endof
            bl of drop true endof    \ space=exit loop
        endcase
        1/8
    until ;
