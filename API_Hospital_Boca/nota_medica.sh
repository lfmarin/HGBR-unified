#!/bin/bash
#
# GENERACION DOCUMENTO NOTA MEDICA (PG1)
# Este documento contiene dos paginas, que serán combinadas al terminar de procesar la información,
# por medio de ImageMagick.
#

############
# Declara los argumentos agregados antes de actuar.
while [ $# -gt 0 ]; do
    if [[ $1 == "--"* ]]; then
        v="${1/--/}"
        declare "$v"="$2"
		echo "$v=$2"
        shift
    fi
    shift
done
############
NOMTEMP="nota-temp-$NUMEXPEDIENTE"

convert nota-p1.png \
-pointsize 22 -annotate +230+264 "$NOMPACIENTE" \
-annotate +867+264 "$NUMEXPEDIENTE" $NOMTEMP.png

# Fecha nacimiento
convert $NOMTEMP.png \
-pointsize 18 -annotate +210+303 "$DIA" \
-annotate +290+303 "$MES" \
-annotate +365+303 "$YEAR" \
-annotate +515+303 "$EDAD" \
-annotate +664+303 "$GENERO" \
-annotate +867+303 "$NUMSEGURO" \
-annotate +189+343 "$SERVICIO" \
-annotate +639+343 "$DIAGNOSTICO" $NOMTEMP.png
# Registro Medico
convert $NOMTEMP.png \
-pointsize 22 -style Oblique -annotate +309+482 "NOTA PREOPERATORIA" \
-pointsize 18 -style Normal -annotate +309+512 "DIAGNOSTICO PREOPERATORIO:" \
-pointsize 18 -annotate +309+532 "$DIAGNOSTICO_PRE" \
-pointsize 18 -annotate +309+562 "CIRUGÍA PROGRAMADA:" \
-pointsize 18 -annotate +309+582 "$CIRUGIA_PROG" \
-pointsize 18 -annotate +309+612 "FECHA CIRUGIA:" \
-pointsize 18 -annotate +550+612 "$FECHA_CIR" \
-pointsize 18 -annotate +309+632 "TIPO DE ANESTESIA:" \
-pointsize 18 -annotate +550+632 "$TIPO_ANES" \
-pointsize 18 -annotate +309+652 "PREPARACIÓN:" \
-pointsize 18 -annotate +550+652 "$PREP" \
-pointsize 18 -annotate +309+672 "CIRUJANO:" \
-pointsize 18 -annotate +550+672 "$CIRUJANO" $NOMTEMP.png
##

convert $NOMTEMP.png \
-pointsize 22 -style Oblique -annotate +309+706 "NOTA POST QUIRÚRGICA" \
-pointsize 18 -style Normal -annotate +309+736 "DIAGNOSTICO PREOPERATORIO:" \
-pointsize 18 -annotate +309+756 "$DIAGNOSTICO_PRE" \
-pointsize 18 -style Normal -annotate +309+780 "CIRUGÍA PROGRAMADA:" \
-pointsize 18 -annotate +309+800 "$CIRUGIA_PROG" \
-pointsize 18 -style Normal -annotate +309+825 "CIRUGÍA REALIZADA:" \
-pointsize 18 -annotate +309+845 "$CIRUGIA_PROG" \
-pointsize 18 -style Normal -annotate +309+870 "DIAGNOSTICO POSTOPERATORIO:" \
-pointsize 18 -annotate +309+890 "$DIAGNOSTICO_POS" \
-pointsize 18 -style Normal -annotate +309+915 "COMPLICACIONES:" \
-pointsize 18 -annotate +550+915 "$COMPLICACION" \
-pointsize 18 -annotate +309+940 "DESCRIPCIÓN DE LA TÉCNICA:" \
$NOMTEMP.png

# https://stackoverflow.com/questions/29705924/positioning-a-caption-over-a-background-using-rmagick-or-imagemagick

convert								\
  -background '#0000'				\
  -fill black						\
  -geometry +320+950				\
  -pointsize 18						\
  -size 680x caption:"$DESCRIPCION"	\
   $NOMTEMP.png						\
  +swap								\
  -composite						\
   $NOMTEMP.png

echo "png -> pdf"
convert $NOMTEMP.png $NOMTEMP.pdf
rm $NOMTEMP.png
echo "terminado"