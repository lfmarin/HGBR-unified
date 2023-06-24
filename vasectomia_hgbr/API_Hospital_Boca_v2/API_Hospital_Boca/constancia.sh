#!/bin/bash
# Convierte la primera imagen con la informacion que tenemos actualmente.

###
# Declara los valores de argumentos.
###
while [ $# -gt 0 ]; do
    if [[ $1 == "--"* ]]; then
        v="${1/--/}"
        declare "$v"="$2"
		echo "$v=$2"
        shift
    fi
    shift
done
###

DIA=$(date +'%d')
YEAR=$(date +'%Y')
HORA=$(date +'%H')
MINUTO=$(date +'%M')
echo "Comenzando creacion de imagen"

ARCHIVO="const_$IDPACIENTE"

convert const.png \
-gravity West -pointsize 22 -annotate +330-524 "Hospital General de Boca del Rio" \
-gravity West -pointsize 22 -annotate +350-434 "$NOMPACIENTE" \
-gravity West -pointsize 22 -annotate +270-480 "$DIA" \
-gravity West -pointsize 22 -annotate +420-480 "$MES" \
-gravity West -pointsize 22 -annotate +590-480 "$YEAR" \
-gravity West -pointsize 22 -annotate +810-480 "$HORA" \
-gravity West -pointsize 22 -annotate +920-480 "$MINUTO" \
-gravity West -pointsize 22 -annotate +230+430 "$TESTIGO1" \
-gravity West -pointsize 22 -annotate +628+440 "$TESTIGO2" \
-gravity West -pointsize 22 -annotate +270+520 "$MEDICOENCARGADO" \
-gravity West -pointsize 22 -annotate +628+340 "$PERSONAL" \
-gravity West -pointsize 22 -annotate +220+326 "$NOMPACIENTE" \
$ARCHIVO.png

# Una vez hecho todo esto, convierte el resultado a un PDF.
convert $ARCHIVO.png $ARCHIVO.pdf
# Borra el archivo temporal, no lo necesitamos.
rm $ARCHIVO.png

echo "terminado"

# /etc/ImageMagick-6/policy.xml, remove PDF
