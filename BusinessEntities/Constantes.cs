using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("4E5963BB-42D5-409D-9F0E-9D9E1F0B7703")]
    public class Constantes
    {
        public static readonly string PARAM_GRAL_COD_FACULTAD_VALIDOS_PODERES = "COD_FACULTAD_VALIDOS_PODERES";
        public static readonly string PARAM_GRAL_COD_PODERES_VALIDOS = "COD_PODERES_VALIDOS";
        public static readonly string PARAM_GRAL_COD_VINCULOS_PODER_VALIDOS = "COD_VINCULOS_PODER_VALIDOS";

        //RFC 2134 Poderes externos
        public static readonly string PARAM_GRAL_PODERES_EXT_CANT_VALIDOS = "PODERES_EXT_CANT_VALIDOS";
        public static readonly string PARAM_GRAL_PODERES_EXT_COD_FACULT_VALID = "PODERES_EXT_COD_FACULT_VALID";
        public static readonly string PARAM_GRAL_PODERES_EXT_ESTADOS_VALIDADOR = "PODERES_EXT_ESTADOS_VALIDADOR";

        //RFC 151517 Poderes especiales
        public static readonly string PARAM_GRAL_PODERES_MAX_CANT_ESPECIALES = "MAX_PODERES_ESPECIALES";
        public static readonly string PARAM_GRAL_PODERES_TIPOS_VALIDOS_ESPECIALES = "TIPO_PODERES_ESPECIALES";
        public static readonly string PARAM_GRAL_PODERES_FACULTAD_VALIDAS_ESPECIALES = "FACULTAD_PODERES_ESPECIALES";
        public static readonly string PARAM_GRAL_PODERES_ESTADOS_VALIDOS_ESPECIALES = "ESTADOS_PODERES_ESPECIALES";

        //Tipo poderes
        public const string COD_PODER_INTERNO = "1";
        public const string COD_PODER_EXTERNO = "2";
        public const string COD_PODER_PAGO_UNICA_VEZ = "3";
        public const string COD_PODER_TUTELA = "4";
        public const string COD_PODER_CURATELA = "5";
        public const string COD_PODER_PATRIA_POTESTAD = "6";
        public const string COD_PODER_REGISTRO_SUCESION = "7";
        public const string COD_PODER_AUTORIZACION_COBRO = "8";
        public const string COD_PODER_AUTORIZACION_JUDICIAL = "9";
        public const string COD_PODER_RESOLUCION_2815 = "10";
        public const string COD_PODER_TITULAR_CON_ASISTENCIA = "11";

        public const string GRUPO_PODERES_FACULT_COBRO = "PODERES_FACULT_COBRO";
        public const string GRUPO_PODERES_COBRO_MIXTO = "PODERES_COBRO_MIXTO";
        public const string GRUPO_PODERES_COBRO_SOLO_APO = "PODERES_COBRO_SOLO_APO";
        public const string GRUPO_ACTUACION_CONJUNTA = "ACTUACION_CONJUNTA";

        //COD_VINCULOS
        public const int COD_VINCULO_ABOGADO= 1;
        public const int COD_VINCULO_PROCURADOR = 2;
        public const int COD_VINCULO_FAMILIAR = 3;
        public const int COD_VINCULO_ESPECIAL = 4;

        public static readonly string UACT_DEBUG = "BPSRING";

        public const string ESTADO_OTORGADO = "O";
        public static readonly string DESC_ESTADO_OTORGADO = "OTORGADO";
        public const string ESTADO_PENDIENTE = "P";
        public static readonly string DESC_ESTADO_PENDIENTE = "PENDIENTE";


        public static readonly List<int> codigosFacultadValidos = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
        public static readonly List<int> codigosPoderesValidos = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static readonly List<int> codigosVinculoValidos = new List<int>() { 1, 3, 4, 5 };
        public static readonly List<String> codigosEstadoValidos = new List<string>() { "O", "P" };

        public static readonly int MAX_LEN_COMENTARIOS = 250;

        public enum CodigosError
        {
            [StringValue("USUARIO INCORRECTO")]
            ERROR_USUARIO_INCORRECTO = 3858,

            [StringValue("IDENTIFICADOR DE PERSONA INVALIDO")]
            ERROR_IDENTIFICADOR_DE_PERSONA_INVALIDO = 3859,

            [StringValue("IDENTIFICADORES DE PERSONAS INVALIDO")]
            ERROR_IDENTIFICADORES_DE_PERSONAS_INVALIDO = 3860,

            [StringValue("CODIGO DE FACULTAD DE PODER INVALIDO")]
            ERROR_CODIGO_DE_FACULTAD_DE_PODER_INVALIDO = 3861,

            [StringValue("CODIGO DE PODER INVALIDO")]
            ERROR_CODIGO_DE_PODER_INVALIDO = 3862,

            [StringValue("FECHA DESDE DEL PODER DEBE SER MENOR O IGUAL A LA FECHA HASTA")]
            ERROR_FECHA_DESDE_MENOR_FECHA_HASTA = 3863,

            [StringValue("CODIGO DE VINCULO DE PODER INVALIDO")]
            ERROR_CODIGO_VINCULO_PODER_INVALIDO = 3864,

            [StringValue("ORIGEN INVALIDO")]
            ERROR_CODIGO_ORIGEN_INVALIDO = 3876,

            [StringValue("ESTADO DE PODER INVALIDO")]
            ERROR_ESTADO_PODER_INVALIDO = 3865,

            [StringValue("LOS COMENTARIOS DEL PODER SUPERAN EL MAXIMO PERMITIDO")]
            ERROR_COMENTARIOS_PODER_SUPERAN_MAXIMO_PERMITIDO = 3866,

            [StringValue("NO SE PERMITE INGRESAR PODERES PARA PERSONAS FALLECIDAS")]
            ERROR_NO_PERMITE_INGRESAR_PODERES_PARA_PERSONAS_FALLECIDAS = 3869,

            //RFC 2134 
            [StringValue("NO SE PERMITE INGRESAR PODERES EXT, LA PERSONA SUPERA LA CANTIDAD DE PODERES EXT PERMITIDA")]
            ERROR_SUPERA_CANT_PODERES_EXT_PERMITIDA = 3929,

            //RFC 151517
            [StringValue("YA EXISTEN CUATRO PODERES DE NO FAMILIAR PARA ÉSTA PERSONA")]
            ERROR_MAX_CANT_PODERES_ESPECIALES = 4117

        }        
    }

    public class StringValue : System.Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}
