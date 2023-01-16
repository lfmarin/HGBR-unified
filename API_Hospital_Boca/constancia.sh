#!/bin/bash
# Convierte la primera imagen con la informacion que tenemos actualmente.
NOMPACIENTE=$1
IDPACIENTE=$2
TESTIGO1=$3
TESTIGO2=$4
MEDICOENCARGADO=$5

DIA=$(date +'%d')
MES=$(date +'%h')
YEAR=$(date +'%Y')

HORA=$(date +'%H')
MINUTO=$(date +'%M')
echo "Comenzando creacion de imagen"
echo $(pwd)

ARCHIVO="const_$IDPACIENTE"

convert const.png -gravity West -pointsize 22 -annotate +350-434 "$NOMPACIENTE" $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +270-480 $DIA $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +420-480 $MES $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +590-480 $YEAR $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +810-480 $HORA $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +920-480 $MINUTO $ARCHIVO.png

# Hora de imprimir la información dada de los testigos.
# convert temp.png -gravity West -pointsize 22 -annotate +240+328 $TESTIGO1 temp.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +230+430 "$TESTIGO1" $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +628+440 "$TESTIGO2" $ARCHIVO.png
convert $ARCHIVO.png -gravity West -pointsize 22 -annotate +270+520 "$MEDICOENCARGADO" $ARCHIVO.png

# Una vez hecho todo esto, convierte el resultado a un PDF.
convert $ARCHIVO.png $ARCHIVO.pdf
# Borra el archivo temporal, no lo necesitamos.
rm $ARCHIVO.png

echo "terminado"

# /etc/ImageMagick-6/policy.xml, remove PDF