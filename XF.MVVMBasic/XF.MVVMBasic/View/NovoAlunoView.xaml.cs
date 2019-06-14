﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAlunoView : ContentPage
	{
        AlunoViewModel vmAluno; 

        public NovoAlunoView ()
		{
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;
            InitializeComponent();
		}
	}
}