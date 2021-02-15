using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MihaZupan;
using Telegram.Bot.Types.ReplyMarkups;
using System.IO;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;

namespace BotManager
{
    public partial class frmBotManager : Form
    {
        private static string Token = "";
        private Thread ThreadBot;
        private Telegram.Bot.TelegramBotClient Bot;
        BotManagerEntities db = new BotManagerEntities();

        public string Link;
        private string FileNameExtension = "";
        OpenFileDialog File;
        FileStream ImageStream = null;

        public frmBotManager()
        {
            InitializeComponent();
        }

        private void runBot()
        {
            Bot = new Telegram.Bot.TelegramBotClient(Token);

            this.Invoke(new Action(() =>
            {
                lblStatus.Text = "Online";
                lblStatus.ForeColor = Color.Green;
            }));
            int offset = 0;

            while (true)
            {
                try
                {
                    Telegram.Bot.Types.Update[] Update = Bot.GetUpdatesAsync(offset).Result;

                    foreach (Telegram.Bot.Types.Update Up in Update)
                    {
                        offset = Up.Id + 1;
                        while (Up.CallbackQuery != null)
                        {
                            //Contatct To Me Inline
                            if (Up.CallbackQuery.Data.Contains("gmail")) { Bot.SendTextMessageAsync(Up.CallbackQuery.Message.Chat.Id, "My Gmail address is : shayestehhs1@Gmail.com"); Up.CallbackQuery = null; break; }
                            else if (Up.CallbackQuery.Data.Contains("outlook")) { Bot.SendTextMessageAsync(Up.CallbackQuery.Message.Chat.Id, "My Outlook address is : Shyestehhs@outlook.com"); Up.CallbackQuery = null; break; }
                            //Poll Inline
                            var user = db.PollManager.SingleOrDefault(u => u.UserID == Up.CallbackQuery.From.Id);
                            if (user == null)
                            {
                                user = new PollManager()
                                {
                                    UserID = Up.CallbackQuery.From.Id,
                                    VotedByUser = ""
                                };
                                db.PollManager.Add(user);
                                db.SaveChanges();
                            }
                            var UserID = Up.CallbackQuery.From.Id;
                            var pUserID = db.PollManager.Select(p => p.UserID).ToList();
                            var pVotedByUSer = db.PollManager.Select(p => p.VotedByUser).ToList();
                            var query = Up.CallbackQuery.Data;

                            string VotedNow = Up.CallbackQuery.Data;
                            if (db.PollManager.Any(p => (p.UserID == Up.CallbackQuery.From.Id) && (p.VotedByUser != VotedNow)))
                            {
                                Poll(Up, db.PollManager.SingleOrDefault(a => a.UserID == UserID).VotedByUser, VotedNow);

                                InlineKeyboardMarkup PollButons = PollInline();
                                Bot.EditMessageReplyMarkupAsync(Up.CallbackQuery.Message.Chat.Id, Up.CallbackQuery.Message.MessageId, replyMarkup: PollButons);
                                Up.CallbackQuery = null;
                            }
                            else { Bot.SendTextMessageAsync(Up.CallbackQuery.Message.Chat.Id, "You have rated before"); }
                            Up.CallbackQuery = null;
                        }


                        if (Up.Message == null) { continue; }

                        string MessageFromUser = Up.Message.Text.ToLower();
                        Telegram.Bot.Types.User Upfrom = Up.Message.From;
                        Telegram.Bot.Types.ChatId ChatID = Up.Message.Chat.Id;

                        StringBuilder SB = new StringBuilder();
                        if (MessageFromUser.Contains("start"))
                        {
                            ReplyKeyboardMarkup MainKeyboardMarkup = StartKeyboards();
                            SB.AppendLine("Welcome To My Bot");
                            SB.AppendLine("Contact To Me : /ContactToMe");
                            SB.AppendLine("About Me : /AboutMe");
                            Bot.SendTextMessageAsync(ChatID, SB.ToString(), parseMode: default, false, true, 0, MainKeyboardMarkup);
                        }
                        else if (MessageFromUser.Contains("contacttome"))
                        {
                            ContactToMeKeyboards();
                            SB.AppendLine("Please Choose one of this buttons");

                            InlineKeyboardMarkup urlButons = new InlineKeyboardMarkup(new[]
                            {
                                new []
                                {
                                    InlineKeyboardButton.WithCallbackData("Gmail" + "\U0001F4E7" ,"gmail"),
                                    InlineKeyboardButton.WithCallbackData("OutLook" + "\U0001F17E" ,"outlook"),
                                },
                                new[]
                                {
                                    InlineKeyboardButton.WithUrl("GitHub" + "\U0001F431" ,"https://github.com/ShayestehHS"),
                                }
                            });
                            Bot.SendTextMessageAsync(ChatID, SB.ToString(), replyMarkup: urlButons);
                        }
                        else if (MessageFromUser.Contains("aboutme"))
                        {
                            ReplyKeyboardMarkup BackKeyboardMarkup = BackToFirst();
                            SB.AppendLine("My name is Hossein Shayesteh");
                            SB.AppendLine("and");
                            SB.AppendLine("you can see my CV at my github page");
                            SB.AppendLine("");
                            SB.AppendLine("/ContactToMe");
                            Bot.SendTextMessageAsync(ChatID, SB.ToString(), parseMode: default, false, true, 0, BackKeyboardMarkup);
                        }
                        else if (MessageFromUser.Contains("back"))
                        {
                            ReplyKeyboardMarkup MainKeyboardMarkup = BackToFirst();
                            Bot.SendTextMessageAsync(ChatID, "/Back", parseMode: default, false, true, 0, MainKeyboardMarkup);
                        }
                        else if (MessageFromUser.Contains("poll"))
                        {
                            SB.AppendLine("Scale one to three,How you rate for my bot?");
                            InlineKeyboardMarkup PollButons = PollInline();
                            Bot.SendTextMessageAsync(ChatID, SB.ToString(), replyMarkup: PollButons);
                        }

                        this.Invoke(new Action(() =>
                    {
                        dgvLog.Rows.Add(ChatID, Up.Message.From.Username, Up.Message.Text, Up.Message.MessageId, DateTime.Now.ToString("dd - hh:mm:ss"));
                    }));
                    }
                }
                catch (System.AggregateException) { MessageBox.Show("I think you should turn on your vpn"); }
                catch { MessageBox.Show("An error accured"); }
            }
        }

        private void frmBotManager_Load(object sender, EventArgs e)
        {
            ThreadBot = new Thread(new ThreadStart(runBot));
        }

        //Keyboard and Inline Creators
        private InlineKeyboardMarkup PollInline()
        {
            InlineKeyboardMarkup PollButons = new InlineKeyboardMarkup(new[]
            {
              new []
              {
                 InlineKeyboardButton.WithCallbackData("1 = Best" + $"({db.PollList.SingleOrDefault(a => a.PollTitle == "Best").NumbersOfVote})" ,"Best")
              },
              new[]
               {
                 InlineKeyboardButton.WithCallbackData("2 = Good" + $"({db.PollList.SingleOrDefault(a => a.PollTitle == "Good").NumbersOfVote})" ,"Good"),
               },
              new[]
              {
                 InlineKeyboardButton.WithCallbackData("3 = Awful" + $"({db.PollList.SingleOrDefault(a => a.PollTitle == "Awful").NumbersOfVote})" ,"Awful"),
              }
            });
            return PollButons;
        }

        private ReplyKeyboardMarkup StartKeyboards()
        {
            /// Start keyboards
            ReplyKeyboardMarkup MainKeyboardMarkup = new ReplyKeyboardMarkup();

            KeyboardButton[] Start =
            {
              new  KeyboardButton("Start")
            };

            KeyboardButton[] Poll =
            {
             new KeyboardButton("Poll")
            };
            KeyboardButton[] AboutMe =
            {
              new KeyboardButton("AboutMe")
            };
            KeyboardButton[] ContactToMe =
             {
             new KeyboardButton("ContactToMe")
            };

            KeyboardButton[] MyCourse =
            {
             new KeyboardButton("ContactToMe")
            };
            KeyboardButton[] AllCourses =
            {
             new KeyboardButton("ContactToMe")
            };

            MainKeyboardMarkup.Keyboard = new KeyboardButton[][]
            {
                Start,
                Poll,
                AboutMe,
                ContactToMe,
            };
            return MainKeyboardMarkup;
        }

        private ReplyKeyboardMarkup ContactToMeKeyboards()
        {
            ///Contact to me keyboards
            ReplyKeyboardMarkup ContactKeyboardMarkup = new ReplyKeyboardMarkup();
            KeyboardButton[] ContactRow1 =
            {
              new  KeyboardButton("Gamil")
            };
            KeyboardButton[] ContactRow2 =
             {
              new KeyboardButton("OutLook")
            };
            KeyboardButton[] ContactRow3 =
             {
             new KeyboardButton("GitHub")
            };
            KeyboardButton[] ContactRow4 =
             {
             new KeyboardButton("Show me all of this")
            };
            KeyboardButton[] Back =
             {
             new KeyboardButton("Back")
            };
            ContactKeyboardMarkup.Keyboard = new KeyboardButton[][]
            {
                ContactRow1,
                ContactRow2,
                ContactRow3,
                ContactRow4,
                Back
            };
            return ContactKeyboardMarkup;
        }

        private ReplyKeyboardMarkup BackToFirst()
        {
            ///Back to first keyboard
            ReplyKeyboardMarkup BackKeyboardMarkup = new ReplyKeyboardMarkup();
            KeyboardButton[] Back =
             {
             new KeyboardButton("Back")
            };
            BackKeyboardMarkup.Keyboard = new KeyboardButton[][]
            {
                Back
            };
            return BackKeyboardMarkup;
        }

        //Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            Token = txtToken.Text;
            ThreadBot.Start();
            StartKeyboards();
        }

        private void frmBotManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadBot.Abort();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            //
            int IsValid = 0;

            if (dgvLog.CurrentRow == null)
            {
                if (txtChannelID.Text == "")
                {
                    MessageBox.Show("Please select a row OR aad ChannelID");
                }
                else { IsValid = 1; }
            }
            else
            {
                IsValid = 2;
            }


            if (IsValid != 0)
            {
                ChatId ChatID;
                if (IsValid == 1)
                {
                    ChatID = (ChatId)txtChannelID.Text;
                }
                else
                {
                    ChatID = (ChatId)dgvLog.CurrentRow.Cells[0].Value;
                }
                if (txtPath.Text == "")
                {
                    if (txtCaption.Text != null)
                    {
                        Bot.SendTextMessageAsync(ChatID, txtCaption.Text);
                    }
                    else { MessageBox.Show("Please fill the Caption TextBox"); }
                }
                else
                {
                    if (FileNameExtension.Contains(".jpg") || FileNameExtension.Contains(".png"))
                    {
                        Bot.SendPhotoAsync(ChatID, new InputOnlineFile(ImageStream, "1234.jpg"), txtCaption.Text);
                    }
                    else { Bot.SendPhotoAsync(ChatID, new InputOnlineFile(ImageStream, "1234.mp4"), txtCaption.Text); }
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            File = new OpenFileDialog();
            if (File.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = File.FileName;
                FileNameExtension = Path.GetExtension(txtPath.Text).ToString();
                ImageStream = System.IO.File.Open(txtPath.Text, FileMode.Open);
            }

        }
        //Other
        private void Poll(Telegram.Bot.Types.Update Up, string VotedBefore, string VotedNow)
        {
            if (db.PollManager.Any(u => u.UserID == Up.CallbackQuery.From.Id))
            {
                db.PollList.SingleOrDefault(a => a.PollTitle == VotedBefore).NumbersOfVote -= 1;
                db.PollList.SingleOrDefault(a => a.PollTitle == VotedNow).NumbersOfVote += 1;
                db.PollManager.SingleOrDefault(a => a.UserID == Up.CallbackQuery.From.Id).VotedByUser = VotedNow;
                db.SaveChanges();
            }

        }
    }
}
