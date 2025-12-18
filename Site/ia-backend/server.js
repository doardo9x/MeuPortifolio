import 'dotenv/config';
import express from 'express';
import cors from 'cors';
import fetch from 'node-fetch';

const app = express();

app.use(cors());
app.use(express.json());

app.post('/api/ia', async (req, res) => {
    const { message } = req.body;

    if (!message) {
        return res.status(400).json({ error: 'Mensagem vazia' });
    }

    try {
        const response = await fetch('https://api.groq.com/openai/v1/chat/completions', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${process.env.GROQ_API_KEY}`
            },
            body: JSON.stringify({
                model: 'llama-3.1-8b-instant',
                messages: [
                    {
                        role: 'system',
                        content: 'Você é uma inteligência artificial geral, capaz de ajudar em qualquer assunto.'
                    },
                    {
                        role: 'user',
                        content: message
                    }
                ],
                temperature: 0.7
            })
        });

        const data = await response.json();

        console.log('RESPOSTA COMPLETA GROQ:', data);

        if (!data.choices) {
            return res.status(500).json({ error: 'Erro ao gerar resposta da IA' });
        }

        res.json({
            reply: data.choices[0].message.content
        });

    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Erro interno do servidor' });
    }
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Servidor rodando na porta ${PORT}`);
});
