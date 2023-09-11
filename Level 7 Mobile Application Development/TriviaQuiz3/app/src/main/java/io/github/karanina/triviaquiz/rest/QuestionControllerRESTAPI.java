package io.github.karanina.triviaquiz.rest;

import android.util.Log;

import java.util.List;

import io.github.karanina.triviaquiz.model.Question;
import io.github.karanina.triviaquiz.model.Questions;
import io.github.karanina.triviaquiz.model.Quiz;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class QuestionControllerRESTAPI implements retrofit2.Callback<Questions> {

    final String BASE_URL = "https://opentdb.com/";
    private Questions questions;
    final int maxQuestions = 10;
    List<Question> questionList;
    Quiz quiz = new Quiz();


    public void start(String difficulty, int categoryID) {
    Retrofit retrofit = new Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(GsonConverterFactory.create())
            .build();
    QuestionRESTAPI questionRESTAPI = retrofit.create(QuestionRESTAPI.class);
    Call<Questions> call = questionRESTAPI.getQuestions(maxQuestions, categoryID, difficulty, "multiple");
    call.enqueue(this);
}


    @Override
    public void onResponse(Call<Questions> call, Response<Questions> response) {
        if (response.isSuccessful()) {
            questions = response.body();
            questionList = questions.getValue();
            if (questionList != null) {
                    quiz.setCategory(questions.getQuizCategory());
                quiz.setDifficulty(questions.getQuizDifficulty());
                for (Question q : questionList) {
                    Question question = new Question(q.getQuestion(), q.getCorrect_answer(), q.getIncorrect_answers());
                    quiz.addQuestion(question);
                    Log.d("QUESTION_LIST", "Question: " + q.toString());
                }
                Log.d("QUIZ", quiz.toString());
            } else {
                Log.d("QUESTION_LIST", "Question list is empty.");
            }
        }
    }

    @Override
    public void onFailure(Call<Questions> call, Throwable t) {
        t.printStackTrace();
    }

    public Quiz getQuiz(){
        return quiz;
    }
}
