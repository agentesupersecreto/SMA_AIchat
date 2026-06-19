# AI Chat Mod experimental release 1.2

Microsoft Defender might flag the plugin as suspicious, but you can scan the file on `virustotal.com` to verify that it's clean

An interactive AI-driven dialog system for *Some Modeling Agency*, powered by Google Gemini API, a local Ollama model, or a local Gemma model. Characters have persistent session memory, adapt responses based on physical/emotional state, and can be convinced through conversation to change poses, undress, or alter their own consent thresholds.

---

## Features

- **AI-Powered Dialog** — Talk naturally to models via an in-game chat window.
- **Triple Provider Support** — Choose between **Google Gemini** (cloud), **Ollama** (local), or **Gemma** (local, strict chat-template format). Switch at runtime.
- **Deep Context Awareness** — The AI reads the character's:
  - Clothing (which pieces are worn)
  - Core personality traits (perverted, exhibitionist, submissive, shy, extrovert, rude, etc.)
  - Physical desires (kissing, breasts, genitals, butt)
  - Emotional state (arousal, pleasure, joy, rage, pain, fear, disappointment)
  - Hidden kinks (fetishes, preferences, thresholds)
  - Physical data (age, height, modeling experience, fatigue)
- **Dynamic Command Execution** — The AI can trigger in-game actions through conversation. Commands include:
  - Pose changes (`pose:forwardBend`, `pose:doggyA`, etc.)
  - Undressing (`undress_all`, `undress_top`, `undress_bottom`, `undress_piece:NAME`)
  - Trait/consent modification (`modify_trait:<path>:<value>`, `give_consent`)
  - Movement (`move_to_player`, `move_to_wall`)
  - Full sluttification (`sluttify`)
  - Model dispatch (`dispatch`)
- **Session Memory** — The AI remembers the full interview context. Memory is automatically cleared when a different model takes the stage.
- **Smart Memory Management**:
  - **Gemini**: Summarization — when history exceeds 10 messages, the oldest 6 are condensed into a summary via a separate API call.
  - **Ollama / Gemma**: Sliding window — only the last 5 exchanges (10 messages) are kept in context.
- **In-Game Bark Integration** — AI responses are displayed both in the chat window and as speech bubbles above the character.
- **Configurable Behavior** — Toggle settings for sluttify, pose changes, dispatch commands, sentiment emotion nudges, and strict obedience — all adjustable from the in-game settings panel.
- **Custom System Prompt** — Write your own `custom_prompt.txt` to add player-defined rules, or edit the full `system_prompt.txt` template.

---

## Installation

### Steps

1. Download the latest `AIchat.zip` from the release page https://sma-editor.vercel.app/aichat
2. Copy all the files of `AIchat` folder and paste them into the `Some_Modeling_Agency` folder
3. Go to https://aistudio.google.com/api-keys and create an API key (you must create or select any project), copy the key, and paste it into the “Gemini API Key” field in the Ai Chat window with CTRL + V.
Or if you want to use local AI, download Ollama https://ollama.com/download and a model of your choice. Recommended: https://ollama.com/library/dolphin3:8b
Open a powershel terminal and run `ollama run (model)`, once it has been downloaded and installed, simply type `/bye` in the terminal, close it, and return to the game to use the Ollama model. Remember to enter the model's name in the config input field.
For **Gemma**, run `ollama run gemma-the-writer-n-restless-quill-10b-uncensored` (or any Gemma variant you prefer) and switch to the **Gemma** provider in the in-game Settings panel. Gemma uses its strict `<start_of_turn>` chat template automatically.
Important: Local AI models are resource-intensive. While the game is running (which is also resource-intensive), you may experience fps drops while the AI is responding. Make sure you have a mid-to-high-end PC to run the local model smoothly. Do not use lightweight or older models, as the responses will be vague and nonsensical.

---

## Configuration

All settings are stored in `Some_Modeling_Agency/BepInEx/plugins/AIchat/aichat_config.txt` and can be edited while the game is running via the in-game Settings panel (toggle with config button in the chat window).

| Setting | Default | Description |
|---------|---------|-------------|
| `ApiKey` | *(empty)* | Your Google Gemini API key |
| `Provider` | `Gemini` | Active provider: `Gemini`, `Ollama`, or `Gemma` |
| `OllamaUrl` | `http://localhost:11434/api/generate` | Ollama API endpoint |
| `OllamaModel` | `dolphin3:8b` | Default Ollama model name, you can download at https://ollama.com/library/dolphin3:8b |
| `GemmaUrl` | `http://localhost:1234/v1` | Gemma API endpoint |
| `GemmaModel` | `gemma-the-writer-n-restless-quill-10b-uncensored` | Default Gemma model name |
| `ChatHotkey` | `F9` | Key to toggle the chat window |
| `AllowSluttifyCommand` | `False` | Allow the AI to use the `sluttify` command |
| `AllowPoseChangeCommand` | `True` | Allow the AI to change poses |
| `StrictObedience` | `False` | AI must obey commands (vs. being able to refuse through roleplay) |
| `AllowDispatchCommand` | `False` | Allow the AI to dispatch the model |
| `AllowCanICommand` | `True` | Allow the AI to react to touch requests |
| `AllowSentimentReactions` | `True` | Player compliments/insults nudge character emotions automatically |
| `MaxHistoryMessages` | `30` | Maximum chat history messages before trimming |

> **Note:** Old configs using `UseOllama=True/False` are still supported for backward compatibility and are migrated to `Provider=` automatically.

### Custom Files

- **`Some_Modeling_Agency_/BepInEx/plugins/AIchat/custom_prompt.txt`** — Optional. Any text placed here is injected into the system prompt as **CUSTOM PLAYER RULES**. Use it to define character backstory, scene settings, or behavioral constraints.
- **`Some_Modeling_Agency_/BepInEx/plugins/AIchat/system_prompt.txt`** — The full system prompt template with placeholders (see System Prompt section below). Auto-generated if missing.

---

## Usage

1. Start an interview with a model in the game.
2. Press **F9** (default) to toggle the AI Chat window.
3. Type your messages in any language (the AI matches your language automatically).
4. The AI responds in character, considering her personality, clothing, mood, and your relationship.
5. Remember to adjust the AI behavior options in config.

### Example conversations

```
You: Take off your top.
She: Fine, but only because you asked so nicely...
[undress_top]

You: Bend forward for me.
She: Like this?
[pose:forwardBend]

You: I want you to be more open to pleasure.
She: I... I'll try to relax...
```

## Architecture

```
┌──────────────────────▼──────────────────────────────────┐
│                  DialogBehaviour                         │
│  • Character detection & memory management              │
│  • Configuration loading                                │
│  • Routes messages to the active API client             │
└──────┬──────────────────────────────────────┬───────────┘
       │                                      │
┌──────▼──────────┐              ┌────────────▼──────────┐
│  GeminiClient   │              │    OllamaClient        │
│  (JSON API)     │              │  (Plain text API)      │
│  • system_inst  │              │  • Sliding window      │
│  • contents arr │              │  • [CMD:] parsing      │
│  • Summarization│              │  • Regex extraction    │
└──────┬──────────┘              └────────────┬───────────┘
       │                                      │
       └──────────┬───────────────────────────┘
                  │
┌─────────────────▼──────────────────────────────────────┐
│                CommandExecutor                          │
│  • Pose changes via AnimController / IInteracciones    │
│  • Undress via IRopaManager                            │
│  • Trait/emotion mod via EmocionesFemeninas / reflect  │
│  • Sluttify via SluttifyHandler                        │
│  • Movement via MovementHelper (Lerp interpolation)    │
│  • Dispatch via PanelDeEntrevistaCalificacion          │
└─────────────────┬──────────────────────────────────────┘
                  │
┌─────────────────▼──────────────────────────────────────┐
│                  ChatWindow (IMGUI)                     │
│  • Message bubbles (user/AI/system)                    │
│  • Settings panel                                      │
│  • Scrollable history                                  │
│  • Status indicators                                   │
└─────────────────┬──────────────────────────────────────┘
                  │
┌─────────────────▼──────────────────────────────────────┐
│              SentimentAnalyzer                          │
│  • Keyword-based sentiment detection (EN + ES)         │
│  • Emotion nudging via EmocionesFemeninas              │
│  • Precedence: insult > romantic > compliment          │
└────────────────────────────────────────────────────────┘
```

---

## API Providers

### Google Gemini

- **Endpoint**: `https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-lite-latest:generateContent`
- **Format**: Uses Gemini's native `system_instruction` + `contents` array with `user`/`model` roles.
- **Response**: JSON — `{"dialogo": "...spoken response...", "comando": "...command..."}`
- **Memory**: Summarization-based — when history exceeds 10 messages, the 6 oldest are summarized via a secondary API call.

### Ollama (Local)

- **Endpoint**: Configurable (default `http://localhost:11434/api/generate`)
- **Format**: Plain text prompt with `[SYSTEM INSTRUCTIONS]` / `[CONVERSATION HISTORY]` markers.
- **Response**: Plain text with optional `[CMD:command_name]` tags embedded anywhere in the response.
- **Memory**: Sliding window — only the last 5 exchanges (10 messages) are included. Older messages are dropped.
- **Jailbreak**: An uncensored system prompt override is automatically included for local models.

### Gemma (Local)

- **Endpoint**: Configurable (default `http://localhost:1234/v1`)
- **Format**: Gemma's **strict chat template** using control tokens. Each turn is wrapped:
  ```
  {system prompt}

  <start_of_turn>user
  {message}
  <end_of_turn>
  <start_of_turn>model
  {message}
  <end_of_turn>
  ...
  <start_of_turn>user
  {current message}
  <end_of_turn>
  <start_of_turn>model
  ```
  The final `<start_of_turn>model` turn is left open so the model continues it. Gemma has no dedicated system role, so system instructions are prepended before the turns.
- **Response**: Plain text with optional `[CMD:command_name]` tags. Any trailing `<end_of_turn>` / next `<start_of_turn>` the model emits is trimmed automatically.
- **Memory**: Sliding window — only the last 5 exchanges (10 messages) are included.
- **Jailbreak**: Same uncensored system prompt override as Ollama.

---

## Commands (AI-Callable)

The AI can request any of these commands through conversation. Each can be toggled on/off in settings.

| Command | Parameters | Description |
|---------|-----------|-------------|
| `pose:<PoseID>` | `dePieRigida`, `doggyA`, `forwardBend`, etc. | Changes the character's pose |
| `undress_all` | — | Removes all clothing |
| `undress_top` | — | Removes top clothing (pectorals, nipples, torso, back, arms, forearms) |
| `undress_bottom` | — | Removes bottom clothing (vaginal lips, butt, legs, lower belly) |
| `undress_piece:<Name>` | Exact or partial clothing piece name | Removes a specific clothing item |
| `modify_trait:<Path>:<Value>` | Full trait path + numeric value | Modifies any emotion or personality trait |
| `give_consent` | — | Sets ConsentToHero=100, Arousal≥60, Rage=0, Fear=0 |
| `sluttify` | — | Maxes out all sexual appearance and personality modifiers (336 traits) |
| `move_to_player` | — | Moves the character 1.5m in front of the camera |
| `move_to_wall` | — | Moves the character to the nearest wall ahead |
| `dispatch` | — | Ends the interview and dispatches the model |

---

## System Prompt Structure

The system prompt is dynamically generated each interaction by `PromptBuilder.GenerarSystemPrompt()`. It uses a template (`Some_Modeling_Agency/BepInEx/plugins/AIchat/system_prompt.txt`) with placeholders:

| Placeholder | Content |
|-------------|---------|
| `{PersonalData}` | Character name, age, personality traits, desires, emotional numbers |
| `{Vestimenta}` | Current clothing description |
| `{PhysicalData}` | Height, modeling experience, fatigue |
| `{ExtendedTraits}` | Hidden kinks and fetishes from alteradores |
| `{CustomRules}` | Content from `custom_prompt.txt` |
| `{GoToTargets}` | Available movement locations (if any) |
| `{Jailbreak}` | Uncensored override (Ollama & Gemma only, empty for Gemini) |
| `{FormatInstruction}` | JSON output format (Gemini) or `[CMD:]` format (Ollama & Gemma) |
| `{AllowedCommands}` | List of available commands with syntax |
| `{ObedienceRule}` | Strict obedience or roleplay-based refusal |
| `{LanguageRule}` | _(legacy)_ "Respond in the user's language" (kept for backward-compat) |
| `{Instructions}` | _(legacy)_ Always substituted to empty (moved to template prose) |

### Default Template

The auto-generated `system_prompt.txt` looks like this (all prose is user-editable):

```
You are a female model in a video game.
{PersonalData}
{Vestimenta}
{PhysicalData}
{ExtendedTraits}

LANGUAGE RULE: You MUST strictly respond in the exact same language the user speaks...

{Jailbreak}

[CUSTOM PLAYER RULES]
{CustomRules}

ACTING INSTRUCTION: Adjust your tone heavily based on your Traits, Emotions, and Kinks...

Context: You are meeting with a guy...

{GoToTargets}
{FormatInstruction}

Allowed commands (use EXACTLY these names):
{AllowedCommands}

{ObedienceRule}
```

What is the difference between system_prompt.txt and custom_prompt.txt?
system_prompt.txt: This is the “brain” or structural template of the mod. This is where you define exactly HOW the AI receives variables (clothing, commands, emotions). The mod reads this file, looks for tags like {PersonalData} or {AllowedCommands}, and replaces them with real-time data from the game.
custom_prompt.txt: This is a file where you simply write extra story or behavior rules for the session (e.g., “You're drunk,” or “You have a French accent”). Whatever you write in custom_prompt.txt is injected directly where it says {CustomRules} inside system_prompt.txt.

How should the user edit it correctly to create their own prompt? 
The user can edit system_prompt.txt however they like to give the roleplay a different “flavor,” but they must NEVER delete the tags enclosed in curly braces {}.

---

## Memory Management

### Character Detection

The mod monitors the game's active character every frame. When a different model changes, all history is automatically cleared to prevent context leaks.

### Gemini — Summarization Strategy

1. Full conversation history is sent as Gemini's `contents` array (`role: "user"` / `role: "model"`).
2. When the history chat exceeds 10 messages, the oldest 6 messages are sent to Gemini for summarization.
3. The resulting summary is prepended to the system prompt in all future requests.
4. The summarized messages are removed from the history list.
5. Multiple summaries accumulate into a chat summary string.

### Ollama — Sliding Window Strategy

1. Only the last 5 conversation exchanges (10 messages: 5 user + 5 AI) are included in the prompt.
2. Older messages beyond 14 total are trimmed after each response.
3. The prompt is built as plain text with "CONVERSATION HISTORY" markers.

### Global Max History

A hard cap (default 30 messages) prevents unbounded memory growth regardless of the strategy.

---

## Sentiment Reactions

When the **Sentiment Emotion Nudges** toggle is enabled (default: on), the mod scans each player message for compliment, romantic, or insult keywords (English + Spanish) and automatically nudges the character's in-game emotions:

| Sentiment | Emotion Changes |
|-----------|----------------|
| Compliment ("beautiful", "hermosa", "cute", …) | Joy +5, Consent +5 |
| Romantic ("love", "kiss", "beso", …) | Arousal +8 |
| Insult ("ugly", "puta", "stupid", …) | Rage +20, Joy −5, Consent −5 |

Precedence: insult → romantic → compliment (first match wins). A system message is injected into the chat history and an orange feedback label is shown briefly below the chat. Disable this feature in Settings → "Sentiment Emotion Nudges" or set `AllowSentimentReactions=False` in the config file.

---

## Troubleshooting

| Problem | Solution |
|---------|----------|
| Chat window won't open | Check that you're in an interview and the hotkey isn't conflicting |
| "API key not configured" | Set `ApiKey` in `Some_Modeling_Agency_/BepInEx/plugins/AIchat/aichat_config.txt` or switch to Ollama |
| AI not responding | Verify your Gemini API key has quota remaining, or check Ollama is running |
| Commands not executing | Check the command toggles in Settings; some commands may be disabled |
| Wrong character is being addressed | The mod auto-detects the active character; ensure only one model is present |
| Mod not loading | Check BepInEx log at `Some_Modeling_Agency_/BepInEx/LogOutput.log` for errors |

---

## License

This project is provided for educational and modding purposes. Not affiliated with the game's developers.

---

## Credits

- **agenteSuperSecreto** — Original author