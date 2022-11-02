#!/bin/sh
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
convert src/const.png -gravity West -pointsize 22 -annotate +350-434 "$NOMPACIENTE" temp.png
convert temp.png -gravity West -pointsize 22 -annotate +270-480 $DIA temp.png
convert temp.png -gravity West -pointsize 22 -annotate +420-480 $MES temp.png
convert temp.png -gravity West -pointsize 22 -annotate +590-480 $YEAR temp.png
convert temp.png -gravity West -pointsize 22 -annotate +810-480 $HORA temp.png
convert temp.png -gravity West -pointsize 22 -annotate +920-480 $MINUTO temp.png

# Hora de imprimir la información dada de los testigos.
# convert temp.png -gravity West -pointsize 22 -annotate +240+328 $TESTIGO1 temp.png
convert temp.png -gravity West -pointsize 22 -annotate +230+430 "$TESTIGO1" temp.png
convert temp.png -gravity West -pointsize 22 -annotate +628+440 "$TESTIGO2" temp.png
convert temp.png -gravity West -pointsize 22 -annotate +270+520 "$MEDICOENCARGADO" temp.png

# Una vez hecho todo esto, convierte el resultado a un PDF.
convert temp.png gen/const_$2.pdf
# Borra el archivo temporal, no lo necesitamos.
rm temp.png

echo "terminado"