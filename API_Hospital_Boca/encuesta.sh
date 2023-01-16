#!/bin/bash
##
# Encuesta de seguimiento a pacientes
##

###
# Declara los valores de argumentos.
###
while [ $# -gt 0 ]; do
    if [[ $1 == "--"* ]]; then
        v="${1/--/}"
        declare "$v"="$2"
		# echo "$v=$2"
        shift
    fi
    shift
done

JURISTICION="VII"
DIA=$(date +'%d')
MES=$(date +'%h')
YEAR=$(date +'%Y')

HORA=$(date +'%H')
MINUTO=$(date +'%M')
FECHA_COMPLETA="$DIA/$MES/$YEAR"
NOMTEMP="encue_$NUMEXPEDIENTE"

convert encuesta.png \
-gravity West -pointsize 22 -annotate +760-504 "$FECHA_COMPLETA" \
-gravity West -pointsize 22 -annotate +460-504 "$JURISTICION" \
-gravity West -pointsize 16 -annotate +690-478 "$CENTRO_SALUD" \
-gravity West -pointsize 22 -annotate +240-430 "$NOMBRE" \
-gravity West -pointsize 22 -annotate +250-406 "$EDAD" \
-gravity West -pointsize 22 -annotate +470-406 "$ESCOLARIDAD" \
-gravity West -pointsize 22 -annotate +770-406 "$OCUPACION" \
-gravity West -pointsize 22 -annotate +270-382 "$NUM_HIJOS" \
-gravity West -pointsize 22 -annotate +540-382 "$EDAD_MENOR" \
-gravity West -pointsize 22 -annotate +750-382 "$RELIGION" \
-gravity West -pointsize 22 -annotate +590-336 "$FECHA_VASECTOMIA" \
-gravity West -pointsize 22 -annotate +590-284 "$INFO_VASECTOMIA" \
-gravity West -pointsize 20 -annotate +740-234 "$ORIENT_VASECTOMIA" $NOMTEMP.png

if [[ $CENTRO_REFERIDO == 1 ]]; then
	convert $NOMTEMP.png \
	-gravity West -pointsize 22 -annotate +186-160 "X" \
	-gravity West -pointsize 16 -annotate +430-162 "$CENTRO_DEF" $NOMTEMP.png
else
	convert $NOMTEMP.png -gravity West -pointsize 22 -annotate +760-160 "X" $NOMTEMP.png
fi

# Hora de generar el trato de personal. Este es generado por un indice, que sera procesado
# por el switch case.
XPOS_PONT=0
case $TRATO_PERSONAL in
	1) XPOS_PONT="+254" ;; # Excelente
	2) XPOS_PONT="+476" ;; # Bueno
	3) XPOS_PONT="+680" ;; # Regular
	4) XPOS_PONT="+906" ;; #Malo
	*) XPOS_PONT="+9000" ;; #?????
esac

convert $NOMTEMP.png -gravity West -pointsize 22 -annotate $XPOS_PONT-62 "X" $NOMTEMP.png

if [[ $SATISFECHO == 1 ]]; then
	XPOS_PONT="+186"
else
	XPOS_PONT="+320"
fi
convert $NOMTEMP.png \
-gravity West -pointsize 22 -annotate $XPOS_PONT+12 "X" \
-gravity West -pointsize 22 -annotate +230+34 "$RAZON_SATISF" $NOMTEMP.png

if [[ $COMPLICACION_CIR == 1 ]]; then
	convert $NOMTEMP.png \
	-gravity West -pointsize 22 -annotate +186+110 "X" \
	-gravity West -pointsize 22 -annotate +290+110 "$COMPLICACION_DESC" $NOMTEMP.png
else
	convert $NOMTEMP.png -gravity West -pointsize 22 -annotate +700+110 "X" $NOMTEMP.png
fi

case $RELACION_SEX in
	1) XPOS_PONT="+214" ;; # Igual
	2) XPOS_PONT="+476" ;; # Mejor
	3) XPOS_PONT="+714" ;; # Peor
	*) XPOS_PONT="+9000" ;; #?????
esac

convert $NOMTEMP.png -gravity West -pointsize 22 -annotate $XPOS_PONT+184 "X" $NOMTEMP.png
if [[ $RELACION_SEX == 3 ]]; then
	convert $NOMTEMP.png -gravity West -pointsize 22 -annotate +350+206 "$RELACION_PEOR" $NOMTEMP.png
fi

convert $NOMTEMP.png \
-gravity West -pointsize 22 -annotate +540+252 "$FECHA_NEGATIVIDAD" \
-gravity West -pointsize 22 -annotate +480+302 "$ESPERMA_LUGAR" $NOMTEMP.png

if [[ $RECOMENDAR_VASEC == 1 ]]; then
	XPOS_PONT="+186"
else
	XPOS_PONT="+320"
fi
convert $NOMTEMP.png \
-gravity West -pointsize 22 -annotate $XPOS_PONT+382 "X" \
-gravity West -pointsize 22 -annotate +230+402 "$RAZON_VASEC" $NOMTEMP.png

if [[ $LUGARREC_VASEC == 1 ]]; then
	XPOS_PONT="+244"
else
	XPOS_PONT="+568"
fi
convert $NOMTEMP.png \
-gravity West -pointsize 22 -annotate $XPOS_PONT+478 "X" \
-gravity West -pointsize 22 -annotate +230+500 "$RAZON_LUGARREC" $NOMTEMP.png

if [[ $MEJORAR_SERV == 1 ]]; then
	XPOS_PONT="+186"
	convert $NOMTEMP.png -gravity West -pointsize 22 -annotate +290+575 "$MEJORAR_RAZON" $NOMTEMP.png
else
	XPOS_PONT="+886"
fi
convert $NOMTEMP.png -gravity West -pointsize 22 -annotate $XPOS_PONT+577 "X" $NOMTEMP.png

echo "png -> pdf"
# Una vez hecho todo esto, convierte el resultado a un PDF.
convert $NOMTEMP.png $NOMTEMP.pdf
rm $NOMTEMP.png

echo "terminado"