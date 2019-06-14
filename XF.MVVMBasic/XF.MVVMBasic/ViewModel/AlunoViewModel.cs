using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.View;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades

        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static ObservableCollection<Aluno> ListaAlunos { get; set; }
        
        public ICommand IncluirAluno {get;}
        public ICommand SalvarAluno {
            get
            {
                return new Command<AlunoViewModel>((aluno) => btnSalvarAluno_Clicked(aluno));
            }
        }

        public ICommand RemoverAluno
        {
            get
            {
                return new Command<Guid>((guid) => btnRemoverAluno_Click(guid));
            }
        }

        #endregion

        public AlunoViewModel()
        {
            this.RM = "";
            this.Nome = "";
            this.Email = "";
            IncluirAluno = new Command(btnIncluirAluno_Clicked);
        }

        public AlunoViewModel(Aluno aluno)
        {
            this.RM = aluno.RM;
            this.Nome = aluno.Nome;
            this.Email = aluno.Email;
            
        }

        public static ObservableCollection<Aluno> GetAluno()
        {
            //var aluno = new Aluno()
            //{
            //    Id = Guid.NewGuid(),
            //    RM = "542621",
            //    Nome = "Anderson Silva",
            //    Email = "anderson@ufc.com"
            //};

            if (ListaAlunos == null)
                ListaAlunos = new ObservableCollection<Aluno>();

            return ListaAlunos;
        }

        public static void InsertAluno(Aluno aluno)
        {         
            if (ListaAlunos == null)
                ListaAlunos = new ObservableCollection<Aluno>();

            ListaAlunos.Add(aluno);            
        }

        private void btnIncluirAluno_Clicked()
        {
            App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = new AlunoViewModel() });
        }

        private void btnSalvarAluno_Clicked(AlunoViewModel alunoView)
        {
            Aluno aluno = new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = alunoView.RM,
                Nome = alunoView.Nome,
                Email = alunoView.Email
            };

            InsertAluno(aluno);

            App.Current.MainPage.Navigation.PushAsync(new AlunoView() { BindingContext = new AlunoViewModel() });
        }

        private void btnRemoverAluno_Click(Guid guid)
        {

            var alunoExcluir = (from x in ListaAlunos
                         where x.Id == guid
                         select x).FirstOrDefault();

            if (alunoExcluir != null)
                ListaAlunos.Remove(alunoExcluir);
        }
    }
}
