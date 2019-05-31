using Notes.Models;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntry : ContentPage
    {
        public NoteEntry()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            await App.Database.DeleteNoteAsync(note);

            await Navigation.PopAsync();
        }
    }

}