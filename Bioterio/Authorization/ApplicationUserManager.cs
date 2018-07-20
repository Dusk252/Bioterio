using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Bioterio.Authorization
{
    public class ApplicationUsersManager
    {
        public static class Operations
        {
            //public static OperationAuthorizationRequirement Create =
            //  new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
            //public static OperationAuthorizationRequirement Read =
            //  new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };
            //public static OperationAuthorizationRequirement Update =
            //  new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };
            //public static OperationAuthorizationRequirement Delete =
            //  new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
        }

        public class Constants
        {
            //public static readonly string CreateOperationName = "Create";
            //public static readonly string ReadOperationName = "Read";
            //public static readonly string UpdateOperationName = "Update";
            //public static readonly string DeleteOperationName = "Delete";

            public static readonly string AdministratorsRole = "Administrator";

            public static readonly Dictionary<string, string> CategoryRoles = new Dictionary<string, string> {
                
            /*Lote area*/
            { "ReadLote", "Ver Lotes" },
            { "CreateLote", "Criar Lotes" },
            { "EditLote", "Editar Lotes" },
            { "DeleteLote", "Eliminar Lotes" },

            /*RegNovoAnimal area*/
            { "ReadRegNovoAnimal", "Ver Registo de Novos Animais" },
            { "CreateRegNovoAnimal", "Criar Registo de Novos Animais" },
            { "EditRegNovoAnimal", "Editar Registo de Novos Animais" },
            { "DeleteRegNovoAnimal", "Eliminar Registo de Novos Animais" },

            /*CircuitoTanque area*/
            { "ReadCircuitoTanques", "Ver Circuito de Tanques" },
            { "CreateCircuitoTanques", "Criar Circuito de Tanques" },
            { "EditCircuitoTanques", "Editar Circuito de Tanques" },
            { "DeleteCircuitoTanques", "Eliminar Circuito de Tanques" },

            /*PlanoAlimentar area*/
            { "ReadPlanoAlimentar", "Ver Plano Alimentar" },
            { "CreatePlanoAlimentar", "Criar Plano Alimentar" },
            { "EditPlanoAlimentar", "Editar Plano Alimentar" },
            { "DeletePlanoAlimentar", "Eliminar Plano Alimentar" },

            /*Tanque area*/
            { "ReadTanque", "Ver Tanques" },
            { "CreateTanque", "Criar Tanques" },
            { "EditTanque", "Editar Tanques" },
            { "DeleteTanque", "Eliminar Tanques" },

            /*Projeto area*/
            { "ReadProjeto", "Ver Projetos" },
            { "CreateProjeto", "Criar Projetos" },
            { "EditProjeto", "Editar Projetos" },
            { "DeleteProjeto", "Eliminar Projetos" },

            /*Equipa area*/
            { "ReadEquipa", "Ver Equipas" },
            { "CreateEquipa", "Criar Equipas" },
            { "EditEquipa", "Editar Equipas" },
            { "DeleteEquipa", "Eliminar Equipas" },

            /*Ensaio area*/
            { "ReadEnsaio", "Ver Ensaios" },
            { "CreateEnsaio", "Criar Ensaios" },
            { "EditEnsaio", "Editar Ensaios" },
            { "DeleteEnsaio", "Eliminar Ensaios" },

            /*Especie area*/
            { "ReadEspecie", "Ver Espécies" },
            { "CreateEspecie", "Criar Espécies" },
            { "EditEspecie", "Editar Espécies" },
            { "DeleteEspecie", "Eliminar Espécies" },

            /*Fornecedor area*/
            { "ReadFornecedor", "Ver Fornecedores" },
            { "CreateFornecedor", "Criar Fornecedores" },
            { "EditFornecedor", "Editar Fornecedores" },
            { "DeleteFornecedor", "Eliminar Fornecedores" },

            /*Registo area*/
            { "ReadRegisto", "Ver Registos" },
            { "CreateRegisto", "Criar Registos" },
            { "EditRegisto", "Editar Registos" },
            { "DeleteRegisto", "Eliminar Registos" },

            /*Localizacao area*/
            { "ReadLocalizacao", "Ver Localização" },
            { "CreateLocalizacao", "Criar Localização" },
            { "EditLocalizacao", "Editar Localização" },
            { "DeleteLocalizacao", "Eliminar Localização" },

            /*Funcionario area*/
            { "ReadFuncionario", "Ver Funcionários" },
            { "CreateFuncionario", "Criar Funcionários" },
            { "EditFuncionario", "Editar Funcionários" },
            { "DeleteFuncionario", "Eliminar Funcionários" },

            /*OutrasConfiguracoes area*/
            { "ReadOutrasConfiguracoes", "Ver Outras Configurações" },
            { "CreateOutrasConfiguracoes", "Criar Outras Configurações" },
            { "EditOutrasConfiguracoes", "Editar Outras Configurações" },
            { "DeleteOutrasConfiguracoes", "Eliminar Outras Configurações" },

            /*Utilizador area*/
            { "ReadUtilizador", "Ver Utilizadores/Perfis" },
            { "CreateUtilizador", "Criar Utilizadores/Perfis" },
            { "EditUtilizador", "Editar Utilizadores/Perfis" },
            { "DeleteUtilizador", "Eliminar Utilizadores/Perfis" },

            };

            ///*Lote area*/
            //public static readonly string CreateLote = "CriarLotes";
            //public static readonly string ReadLote = "VerLotes";
            //public static readonly string EditLote = "EditarLotes";
            //public static readonly string DeleteLote = "EliminarLotes";

            ///*RegNovoAnimal area*/
            //public static readonly string CreateRegNovoAnimal = "CriarRegistoNovosAnimais";
            //public static readonly string ReadRegNovoAnimal = "VerRegistoNovosAnimais";
            //public static readonly string EditRegNovoAnimal = "EditarRegistoNovosAnimais";
            //public static readonly string DeleteRegNovoAnimal = "EliminarRegistoNovosAnimais";

            ///*CircuitoTanque area*/
            //public static readonly string CreateCircuitoTanques = "CriarCircuitoTanques";
            //public static readonly string ReadCircuitoTanques = "VerCircuitoTanques";
            //public static readonly string EditCircuitoTanques = "EditarCircuitoTanques";
            //public static readonly string DeleteCircuitoTanques = "EliminarCircuitoTanques";

            ///*PlanoAlimentar area*/
            //public static readonly string CreatePlanoAlimentar = "CriarPlanoAlimentar";
            //public static readonly string ReadPlanoAlimentar = "VerPlanoAlimentar";
            //public static readonly string EditPlanoAlimentar = "EditarPlanoAlimentar";
            //public static readonly string DeletePlanoAlimentar = "EliminarPlanoAlimentar";

            ///*Tanque area*/
            //public static readonly string CreateTanque = "CriarTanques";
            //public static readonly string ReadTanque = "VerTanques";
            //public static readonly string EditTanque = "EditarTanques";
            //public static readonly string DeleteTanque = "EliminarTanques";

            ///*Projeto area*/
            //public static readonly string CreateProjeto = "CriarProjetos";
            //public static readonly string ReadProjeto = "VerProjetos";
            //public static readonly string EditProjeto = "EditarProjetos";
            //public static readonly string DeleteProjeto = "EliminarProjetos";

            ///*Equipa area*/
            //public static readonly string CreateEquipa = "CriarEquipas";
            //public static readonly string ReadEquipa = "VerEquipas";
            //public static readonly string EditEquipa = "EditarEquipas";
            //public static readonly string DeleteEquipa = "EliminarEquipas";

            ///*Ensaio area*/
            //public static readonly string CreateEnsaio = "CriarEnsaios";
            //public static readonly string ReadEnsaio = "VerEnsaios";
            //public static readonly string EditEnsaio = "EditarEnsaios";
            //public static readonly string DeleteEnsaio = "EliminarEnsaios";

            ///*Especie area*/
            //public static readonly string CreateEspecie = "CriarEspécies";
            //public static readonly string ReadEspecie = "VerEspécies";
            //public static readonly string EditEspecie = "EditarEspécies";
            //public static readonly string DeleteEspecie = "EliminarEspécies";

            ///*Fornecedor area*/
            //public static readonly string CreateFornecedor = "CriarFornecedores";
            //public static readonly string ReadFornecedor = "VerFornecedores";
            //public static readonly string EditFornecedor = "EditarFornecedores";
            //public static readonly string DeleteFornecedor = "EliminarFornecedores";

            ///*Registo area*/
            //public static readonly string CreateRegisto = "CriarRegistos";
            //public static readonly string ReadRegisto = "VerRegistos";
            //public static readonly string EditRegisto = "EditarRegistos";
            //public static readonly string DeleteRegisto = "EliminarRegistos";

            ///*Localizacao area*/
            //public static readonly string CreateLocalizacao = "CriarLocalização";
            //public static readonly string ReadLocalizacao = "VerLocalização";
            //public static readonly string EditLocalizacao = "EditarLocalização";
            //public static readonly string DeleteLocalizacao = "EliminarLocalização";

            ///*Funcionario area*/
            //public static readonly string CreateFuncionario = "CriarFuncionários";
            //public static readonly string ReadFuncionario = "VerFuncionários";
            //public static readonly string EditFuncionario = "EditarFuncionários";
            //public static readonly string DeleteFuncionario = "EliminarFuncionários";

            ///*OutrasConfiguracoes area*/
            //public static readonly string CreateOutrasConfiguracoes = "CriarOutrasConfigurações";
            //public static readonly string ReadOutrasConfiguracoes = "VerOutrasConfigurações";
            //public static readonly string EditOutrasConfiguracoes = "EditarOutrasConfigurações";
            //public static readonly string DeleteOutrasConfiguracoes = "EliminarOutrasConfigurações";

            ///*Utilizador area*/
            //public static readonly string CreateUtilizador = "CriarUtilizadores";
            //public static readonly string ReadUtilizador = "VerUtilizadores";
            //public static readonly string EditUtilizador = "EditarUtilizadores";
            //public static readonly string DeleteUtilizador = "EliminarUtilizadores";
        }
    }
}
