SELECT
    fuo.dt_fim_fup_ocorr       "DT ENTRADA",
    to_char(oco.dt_ocorrencia, 'DD/MM/YYYY HH24:SS') "DT OCORRÊNCIA",
    oco.nr_ocorrencia          "OCORRÊNCIA",
    oco.cd_cir_dentista        "DENTISTA",
    cdt.sg_uf                  "UF",
    cdt.nm_cidade              "CIDADE",
    cdt.cd_usuario_consultor   "USUÁRIO CONSULTOR",
    oco.cd_associado           "ASSOCIADO",
    per.ds_perfil              "ORIGEM",
    (
        SELECT
            ds_perfil
        FROM
            tbod_perfil
        WHERE
            cd_perfil = fuo.cd_perfil_destino
    ) destino,
    TRIM(moo.ds_motivo_ocorr) motivo,
    tio.ds_tipo_ocorr          tipo,
    fuo.cd_usuario_resp,
    (
        SELECT
            nm_usuario
        FROM
            tbod_usuario
        WHERE
            cd_usuario = (
                SELECT
                    cd_usuario_resp
                FROM
                    tbod_fup_ocorr
                WHERE
                    nr_ocorrencia = oco.nr_ocorrencia
                    AND nr_sequencial = '1'
            )
    ) "USUÁRIO ABERTURA",
    (
        SELECT
            ds_perfil
        FROM
            tbod_perfil
        WHERE
            cd_perfil = (
                SELECT
                    cd_perfil_origem
                FROM
                    tbod_fup_ocorr
                WHERE
                    nr_ocorrencia = oco.nr_ocorrencia
                    AND nr_sequencial = '1'
            )
    ) "PERFIL ABERTURA",
    (SELECT CD_EMPRESA FROM TBOD_ASSOCIADO WHERE CD_ASSOCIADO = OCO.CD_ASSOCIADO) "EMPRESA CLIENTE"
FROM
    tbod_fup_ocorr       fuo     
    JOIN tbod_ocorrencia           oco  ON fuo.nr_ocorrencia = oco.nr_ocorrencia
    LEFT JOIN vwod_cir_dentista_todos   cdt ON cdt.cd_cir_dentista = oco.cd_cir_dentista
    JOIN tbod_motivo_ocorr         moo ON moo.cd_motivo_ocorr = oco.cd_motivo_ocorr
    JOIN tbod_perfil               per ON fuo.cd_perfil_origem = per.cd_perfil
    JOIN tbod_tipo_ocorr           tio ON tio.cd_tipo_ocorr = oco.cd_tipo_ocorr
    JOIN tbod_usuario              usu ON usu.cd_usuario = fuo.cd_usuario_resp
WHERE
    fuo.dt_fim_fup_ocorr >= TO_DATE('30/06/2020', 'dd/mm/yyyy hh24:mi:ss')
    AND fuo.dt_fim_fup_ocorr <= TO_DATE('01/07/2020', 'dd/mm/yyyy hh24:mi:ss')
    --AND fuo.nr_sequencial = 1
    AND fuo.cd_perfil_destino IN (
        '46',
        '167',
        '1133',
        '1134',
        '1135',
        '1136',
        '1137',
        '1138',
        '1139',
        '1140',
        '1141',
        '1142',
        '1143',
        '1144',
        '1145',
        '1152',
        '24',
        '10',
        '1110',
        '1111',
        '1112',
        '1113',
        '1106',
        '1107',
        '1108',
        '1109',
        '1115',
        '1164',
        '1165',
        '1166',
        '1183',
        '1206',
        '1207',
        '1208',
        '1209',
        '0001',
        '1305'
    )
ORDER BY
    "DT ENTRADA";