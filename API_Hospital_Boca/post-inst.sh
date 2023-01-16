#!/bin/bash
##
# Instrucciones Post-Operatorias
##

###
# Declara los valores de argumentos.
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

##############
## PAGINA 1 ##
##############
NOMTEMP="post-temp-1-$NUMEXPEDIENTE"

# --NOMMEDICO
# --UNIDAD_MEDICA
# --UNIDAD_DIRECCION
# --NOMPACIENTE

convert post-op_p1.png \
-gravity West -pointsize 22 -annotate +186+422 "$NOMPACIENTE" \
-gravity West -pointsize 22 -annotate +453+533 "$NOMMEDICO" $NOMTEMP.png

##############
## PAGINA 2 ##
##############
NOM2TEMP="post-temp-2-$NUMEXPEDIENTE"

convert post-op_p2.png \
-gravity West -pointsize 22 -annotate +181+229 "$NOMPACIENTE" \
-gravity West -pointsize 22 -annotate +308+335 "$UNIDAD_MEDICA" \
-gravity West -pointsize 22 -annotate +308+382 "$UNIDAD_DIRECCION" \
-gravity West -pointsize 22 -annotate +448+502 "$NOMMEDICO" $NOM2TEMP.png

################
## CONVERSION ##
################

echo "png -> pdf"
# Una vez hecho todo esto, convierte el resultado a un PDF.
convert $NOMTEMP.png $NOM2TEMP.png post-$NUMEXPEDIENTE.pdf
rm $NOMTEMP.png
rm $NOM2TEMP.png

echo "terminado"