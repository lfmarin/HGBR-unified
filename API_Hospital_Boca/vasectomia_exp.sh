#!/bin/bash
#
# GENERACION DOCUMENTO BASECTOMIA (PG1)
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


OCUPACION="${OCUPACION:-SIN TRABAJO}"

## Situacion: Puede suceder que el paciente no tiene hijos.
## Verifica el proceso con una condicion.
if [[ $NUM_HIJOS == 0 ]]; then
	EDAD_MENOR="N./A."
fi

DIA=$(date +'%d')
MES=$(date +'%h')
YEAR=$(date +'%Y')

HORA=$(date +'%H')
MINUTO=$(date +'%M')
FECHA_COMPLETA="$DIA $MES $YEAR"
echo "Comenzando creacion de imagen"

######
# 1 DATOS DE INDENTIFICACION
######

CARPETA="_basectomia"
NOMTEMP="temp$NUMEXPEDIENTE"

convert vas_p1.png \
-gravity West -pointsize 22 -annotate +790-374 "$NUMEXPEDIENTE" \
-gravity West -pointsize 22 -annotate +270-288 "$UNIDAD_MEDICA" \
-gravity West -pointsize 22 -annotate +320-248 "$UNIDAD_DIRECCION , $UNIDAD_TELEFONO" \
-gravity West -pointsize 22 -annotate +150-158 "$NOMPACIENTE" \
-gravity West -pointsize 22 -annotate +150-109 "$FECHA_COMPLETA" \
-gravity West -pointsize 22 -annotate +150-69 "$EDAD" \
-gravity West -pointsize 22 -annotate +530-69 "$FECHA_NACIMIENTO" $NOMTEMP.png

# Hora de generar el estado civil. Este es generado por un indice, que sera procesado
# por el switch case.
XPOS_PONT=0
case $ESTADO_CIVIL in
	1) XPOS_PONT="+348" ;; # Casado
	2) XPOS_PONT="+466" ;; # Soltero
	3) XPOS_PONT="+598" ;; # Divorciado
	4) XPOS_PONT="+710" ;; # Viudo
	*) XPOS_PONT="+856" # Union Libre
esac

if [[ $ESTADO_CIVIL == 1 ]]; then
	echo "El paciente es soltero, no necesita información de relación."
	NOMBRE_ESPOSA="N./A."
	DUR_RELACION="N./A."
fi

convert $NOMTEMP.png \
-gravity West -pointsize 22 -annotate $XPOS_PONT-44 "X" \
-gravity West -pointsize 22 -annotate +150+16 "$ESCOLARIDAD" \
-gravity West -pointsize 22 -annotate +680+16 "$IVS" \
-gravity West -pointsize 20 -annotate +150+56 "$OCUPACION" \
-gravity West -pointsize 22 -annotate +680+56 "$RELIGION" \
-gravity West -pointsize 20 -annotate +150+98 "$REFERENCIA" \
-gravity West -pointsize 20 -annotate +150+140 "$NUM_HIJOS" \
-gravity West -pointsize 20 -annotate +150+182 "$EDAD_MENOR" \
-gravity West -pointsize 20 -annotate +150+222 "$NOMBRE_ESPOSA" \
-gravity West -pointsize 20 -annotate +150+264 "$DUR_RELACION" \
-gravity West -pointsize 20 -annotate +150+306 "$DOMICILIO_ACTUAL" \
-gravity West -pointsize 20 -annotate +150+348 "$DOMICILIO_TELEFONO" \
-gravity West -pointsize 18 -annotate +340+372 "$TRABAJO_ACTUAL" \
-gravity West -pointsize 18 -annotate +250+392 "$TRABAJO_TELEFONO" $NOMTEMP.png

######
# 2 MOTIVO DE SOLICITUD DE PROCEDIMIENTO
######

YPOS_PONT=0
case $MOTIVO_CAUSA_INT_HIJOS in
	1 | 2 | 3)
		XPOS_PONT="+136" ;;
	*)
		XPOS_PONT="+556" ;;
esac

case $MOTIVO_CAUSA_INT_HIJOS in
	1 | 4 ) YPOS_PONT="+478" ;;
	2 | 5 ) YPOS_PONT="+498" ;;
	*) YPOS_PONT="+518" ;;
esac

convert $NOMTEMP.png -gravity West -pointsize 18 -annotate "$XPOS_PONT$YPOS_PONT" "X" $NOMTEMP.png

case $MOTIVO_CAUSA_OPN_PAREJA in
	1) XPOS_PONT="+260" ;;
	2) XPOS_PONT="+526" ;;
	*) XPOS_PONT="+820" ;;
esac
convert $NOMTEMP.png -gravity West -pointsize 18 -annotate "$XPOS_PONT+560" "X" $NOMTEMP.png

case $MOTIVO_CAUSA_PLA_FAMILIAR in
	1) XPOS_PONT="+208" ;;
	2) XPOS_PONT="+336" ;;
	3) XPOS_PONT="+450" ;;
	4) XPOS_PONT="+578" ;;
	5) XPOS_PONT="+680" ;;
	*) XPOS_PONT="+808" ;;
esac
convert $NOMTEMP.png -gravity West -pointsize 18 -annotate "$XPOS_PONT+600" "X" $NOMTEMP.png

######
# 3 Historia Clinica y exploración física
######
NOM2TEMP="temp-2-$NUMEXPEDIENTE"

convert -quiet vas_p2.png \
-pointsize 22 -annotate +768+172 "$NUMEXPEDIENTE" \
-pointsize 22 -annotate +196+300 "$ANTECEDENTES_HEREDOF" \
-pointsize 22 -annotate +196+342 "$ANTECEDENTES_NOPAT" \
-pointsize 22 -annotate +196+406 "$ANTECEDENTES_PAT" \
-pointsize 16 -annotate +237+444 "$TA" \
-pointsize 16 -annotate +325+444 "$PESO" \
-pointsize 16 -annotate +444+444 "$TALLA" \
-pointsize 16 -annotate +545+444 "$FC" \
-pointsize 16 -annotate +630+444 "$FR" \
-pointsize 16 -annotate +720+444 "$TEM" $NOM2TEMP.png

#
case $TIPO_PACIENTE in
	'Sano' ) XPOS_PONT="+240";;
	'Psiquiátrico' ) XPOS_PONT="+384";;
	'Diabético' ) XPOS_PONT="+494";;
	'Hipertenso' ) XPOS_PONT="+622";;
	'Cardiópata' ) XPOS_PONT="+750";;
	* ) XPOS_PONT="+2000";;
esac
convert -quiet $NOM2TEMP.png -pointsize 22 -annotate "$XPOS_PONT+529" "X" $NOM2TEMP.png

convert -quiet $NOM2TEMP.png -pointsize 22 -annotate +196+490 "$EXPLORACION_ORGANOS" $NOM2TEMP.png

#

######
# 4 Procedimiento Quirurgico
######
convert -quiet $NOM2TEMP.png \
-pointsize 22 -annotate +133+615 "$FECHA_CIRUGIA" \
-pointsize 22 -annotate +133+659 "$NOM_CIRUJANO" \
-pointsize 22 -annotate +133+702 "$NOTA_QUIR" \
-pointsize 22 -annotate +133+744 "$PAT_ENCONTRADA" $NOM2TEMP.png

# Una vez hecho todo esto, convierte el resultado a un PDF.
convert $NOMTEMP.png $NOM2TEMP.png vasec_$NUMEXPEDIENTE.pdf
# Borra el archivo temporal, no lo necesitamos.
rm $NOMTEMP.png

echo "terminado"

# /etc/ImageMagick-6/policy.xml, remove PDF
