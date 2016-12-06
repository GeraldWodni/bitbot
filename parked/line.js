function line( x1, y1, x2, y2 ) {
    var dx = x2 - x1;
    var dy = y2 - y1;

    if( Math.abs( dx ) > Math.abs( dy ) ) { // x-wise
    }
    else {  // y-wise
        if( y1 > y2 ) { // swap points
            var x = x2; x2 = x1; x1 = x;
            var y = y2; y2 = y1; y1 = y;
        }

        for( var y = y1; y <= y2; y++ ) {
            var x = x1 + Math.round( dx * (y - y1) / dy );
            console.log( x, y );
        }

        console.log( "--" );
        for( var i = 0; i <= dy; i ++ ) {
            var y = y1 + i;
            var x = x1 + Math.round( dx * i / dy );
            console.log( x, y );
        }
    }
}

line( 1, 5, 2, 9 );
