# AI Chat Mod v1.3

An interactive AI-driven dialog system for *Some Modeling Agency*, powered by Google Gemini API, a local Ollama model, or a local Gemma model. Characters have persistent session memory, a sophisticated psychological simulation engine, and can be convinced through conversation to change poses, undress, alter their consent thresholds, and more.

---

## Features

- **AI-Powered Dialog** — Talk naturally to models via an in-game chat window.
- **Triple Provider Support** — Choose between **Google Gemini** (cloud), **Ollama** (local), or **Gemma** (local). Switch at runtime.
- **Psychology Engine** — The core brain of the mod. The AI reads the character's base-game personality traits and performs dice rolls to initialize a psychological state:
  - Tracks 10 keyword categories across conversations (Seduction, Intimidation, Empathy, Provocation, etc.).
  - Personality traits act as accelerators (e.g., a submissive model reacts strongly to dominance).
  - Tracks extended mood parameters: Boredom, Relief, Thawing, Disgust, and Atmosphere (Cold → Intimate).
  - Modifies in-game arousal, pleasure, consent, joy, and rage based on conversation intent.
- **Dynamic Command Execution** — The AI can trigger in-game actions through conversation. Commands include:
  - Pose changes (`pose:forwardBend`, `pose:doggyA`, etc.)
  - Undressing (`undress_all`, `undress_top`, `undress_bottom`, `undress_piece:NAME`)
  - Trait/consent modification (`modify_trait:<path>:<value>`, `give_consent`)
  - Touch responses (`can_i:PART:ACTION`)
  - Mouth control (`open_mouth`, `close_mouth`)
  - Movement (`go_to:TARGET_ID`)
  - Model dispatch (`dispatch`)
- **Conversation Memory** — The AI remembers the context.
  - Generates a rolling summary of the conversation.
  - Auto-tags important events for long-term memory (e.g., agreements, player name).
  - Memory persists across sessions and is saved per character.
- **Token-Optimized Prompts** — Highly compact, token-efficient system prompts designed to run smoothly on 8GB VRAM local models (like Dolphin or Gemma).
- **Spam Filtering** — Dedups, batches, and sets cooldowns for system messages, reducing chat clutter.
- **Improved UX** — 
  - Chat window supports **Enter to send** and **Shift+Enter for a new line**.
  - Auto-focuses the text box when opened.
  - Integrated Debug panel to view the AI's internal psychological state.
  - Animated "Thinking..." status indicators.

---

## Installation

### Steps

1. Download the latest `AIchat.zip` from the [releases page](https://github.com/agentesupersecreto/SMA_AIchat/releases)
2. Unzip and copy all the files from `AIchat` folder into `Some_Modeling_Agency` game folder (overwriting the existing files).
3. Open the game and start an interview with a model and press F9 to use the mod.

**For Google Gemini (Not recommended, as interactions with the AI ​​are NSFW and violate the API's terms of use)**:
Go to https://aistudio.google.com/api-keys and create an API key (you must create or select any project), copy the key, and paste it into the “Gemini API Key” field in the AI Chat window (CTRL + V).

**For Local AI (Ollama / Gemma) Recommended**:
1. Download Ollama from https://ollama.com/download.
2. Open a powershell terminal, copy and paste this command `ollama run defyma85/gemma-4-E4B-it-ultra-uncensored-heretic-Q4_K_M_gguf` and press Enter.
3. Wait for the download and extraction to complete. Upon success, it will ask you to send a message; simply don't type anything and leave the terminal open (in case you plan to use the mod).
4. Open the game, start an interview with a model, press f9 and switch to the Ollama provider in the config panel and enter the model name (in this case `defyma85/gemma-4-E4B-it-ultra-uncensored-heretic-Q4_K_M_gguf`).
*Note: Local AI models are resource-intensive. Ensure you have a mid-to-high-end PC. Avoid using extremely lightweight or older models, as responses will degrade.*

---

## Configuration

All settings are stored in `Some_Modeling_Agency/BepInEx/plugins/AIchat/aichat_config.txt` and can be edited while the game is running via the in-game config panel (remember save the config by pressing the Save Settings button).

| Setting | Default | Description |
|---------|---------|-------------|
| `ApiKey` | *(empty)* | Your Google Gemini API key |
| `Provider` | `Gemini` | Active provider: `Gemini` or `Ollama` |
| `OllamaUrl` | `http://localhost:11434/api/chat` | Ollama API endpoint |
| `OllamaModel` | `defyma85/gemma-4-E4B-it-ultra-uncensored-heretic-Q4_K_M_gguf` | In case of using Ollama, this is the default model name (you can change it at runtime) |
| `ChatHotkey` | `F9` | Key to toggle the chat window |
| `AllowSluttifyCommand` | `False` | Allow the AI to use the `sluttify` command |
| `AllowPoseChangeCommand` | `True` | Allow the AI to change poses |
| `StrictObedience` | `False` | AI must obey commands (vs. roleplaying refusal) |
| `AllowDispatchCommand` | `False` | Allow the AI to dispatch the model |
| `AllowCanICommand` | `True` | Allow the AI to react to touch requests |
| `AllowDesireManipulation` | `True` | Allow AI to modify Thaw and Desire thresholds |
| `UseNativeDialogueScoring` | `True` | Player compliments/insults nudge character emotions |
| `AllowOpenMouthCommand` | `True` | Allow the AI to open/close her mouth |
| `SpamFilterEnabled` | `True` | Reduce event spam in chat |
| `MaxHistoryMessages` | `30` | Maximum chat history messages kept in memory |

### Custom Files

- **`Some_Modeling_Agency/BepInEx/plugins/AIchat/custom_prompt.txt`** — Optional. Any text placed here is injected into the system prompt as **RULES**. Use it to define character backstory, scene settings, or behavioral constraints.
- **`Some_Modeling_Agency/BepInEx/plugins/AIchat/system_prompt.txt`** — The full system prompt template with placeholders. Auto-generated if missing.

---

## Usage

1. Start an interview with a model in the game.
2. Press **F9** (default) to toggle the AI Chat window.
3. Type your messages (Enter to send, Shift+Enter for a new line). The AI matches your language automatically.
4. The AI responds in character, considering her personality, clothing, mood, memory, and your relationship.

### Example conversations

```
You: Take off your top.
She: Fine, but only because you asked so nicely...
[undress_top]

You: Open your mouth for me.
She: Like this?
[open_mouth]

You: You look beautiful today.
She: Thank you! You're making me blush.
⚡ Sentiment: Compliment detected → Joy +5, Consent +5
```

---

## Architecture & Psychology Engine

The **PsychologyEngine** is the heart of v2.0. It bridges the gap between the game's internal variables and the LLM.

1. **Initialization**: On character load, the engine reads 16 personality modifiers (e.g., Pervertido, Timido, Sumiso). It applies dice rolls to generate starting variance.
2. **Keyword Detection**: The engine scans player messages for 10 keyword categories (Seduction, Intimidation, Empathy, etc.).
3. **Persuasion Dynamics**: 
   - Flattering a shy model warms her up faster.
   - Seducing a perverted model drastically increases Atmosphere.
   - Intimidating a submissive model increases dominance and consent, but intimidating a non-submissive model increases disgust and rage.
4. **Stages**: Replaces the old binary "Discussed" flag. The session moves through: `Discuss` → `Photos` → `Posing` → `Lingerie` → `Erotic`.
5. **Memory**: The ConversationMemory system auto-tags important facts ("She agreed to photos", "Player's name is John") and serializes history to disk per-character.

---

## Commands (AI-Callable)

The AI can request any of these commands through conversation. Each can be toggled on/off in settings.

| Command | Parameters | Description |
|---------|-----------|-------------|
| `pose:<PoseID>` | `dePieRigida`, `doggyA`, `forwardBend`, etc. | Changes the character's pose |
| `undress_all` | — | Removes all clothing |
| `undress_top` | — | Removes top clothing |
| `undress_bottom` | — | Removes bottom clothing |
| `undress_piece:<Name>` | Exact or partial clothing piece name | Removes a specific clothing item |
| `modify_trait:<Path>:<Value>` | Full trait path + numeric value | Modifies any emotion or personality trait |
| `give_consent` | — | Sets ConsentToHero=100, Arousal≥60, Rage=0, Fear=0 |
| `sluttify` | — | Maxes out all sexual appearance and personality modifiers |
| `open_mouth` | — | Opens the model's jaw |
| `close_mouth` | — | Closes the model's jaw |
| `go_to:<Target>` | `Desk`, `Bed`, `Wall`, etc. | Moves the character to a specific spot |
| `dispatch` | — | Ends the interview and dispatches the model |

---

## License

This project is provided for educational and modding purposes. Not affiliated with the game's developers.

---

## Credits

- **agenteSuperSecreto** — Original author
- SMA community suggestions