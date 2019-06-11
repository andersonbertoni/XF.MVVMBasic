using System;
using System.Collections.Generic;
using System.Text;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades

        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static List<Aluno> ListaAlunos { get; set; }        

        #endregion

        public AlunoViewModel()
        {
            this.RM = "";
            this.Nome = "";
            this.Email = "";
        }

        public AlunoViewModel(Aluno aluno)
        {
            this.RM = aluno.RM;
            this.Nome = aluno.Nome;
            this.Email = aluno.Email;
            
        }

        public static List<Aluno> GetAluno()
        {
            //var aluno = new Aluno()
            //{
            //    Id = Guid.NewGuid(),
            //    RM = "542621",
            //    Nome = "Anderson Silva",
            //    Email = "anderson@ufc.com"
            //};

            if (ListaAlunos == null)
                ListaAlunos = new List<Aluno>();

            return ListaAlunos;
        }

        public static bool InsertAluno(Aluno aluno)
        {
            try
            {
                if (ListaAlunos == null)
                    ListaAlunos = new List<Aluno>();

                ListaAlunos.Add(aluno);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
