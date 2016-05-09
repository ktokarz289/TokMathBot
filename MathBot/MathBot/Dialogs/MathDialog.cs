using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;
using PostFix;
using PostfixCalculator;

namespace MathBot.Dialogs
{
	[Serializable]
	public class MathDialog : IDialog<object>
	{
		public async Task StartAsync(IDialogContext context)
		{
			context.Wait(MessageReceivedAsync);
		}

		public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<Message> argument)
		{
			List<string> equation;
			string answer;
			var message = await argument;
			PostfixConverter pf = new PostfixConverter(message.Text);
			equation = pf.ConvertAndReturn();

			PfCalculator pfc = new PfCalculator();
			answer = pfc.CalculatePostfix(equation);
			await context.PostAsync($"The answer is: {answer}");
            context.Wait(MessageReceivedAsync);
		}
	}
}
