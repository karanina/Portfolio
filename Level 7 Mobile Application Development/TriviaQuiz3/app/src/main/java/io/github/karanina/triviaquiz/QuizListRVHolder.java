package io.github.karanina.triviaquiz;

import android.media.Image;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.widget.PopupMenu;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

public class QuizListRVHolder extends RecyclerView.ViewHolder {
    CardView cv_quizList;
TextView db_quizName, db_startDate, db_endDate, db_category, db_difficulty, tv_quizScore, db_quizScore;
Button btn_takeQuiz;
ImageView img_optionsMenu;

    public QuizListRVHolder(@NonNull View itemView) {
        super(itemView);
        cv_quizList = itemView.findViewById(R.id.cv_quizList);
        db_quizName = itemView.findViewById(R.id.db_quizName);
        db_startDate = itemView.findViewById(R.id.db_startDate);
        db_endDate = itemView.findViewById(R.id.db_endDate);
        db_category = itemView.findViewById(R.id.db_category);
        db_difficulty = itemView.findViewById(R.id.db_difficulty);
        btn_takeQuiz = itemView.findViewById(R.id.btn_takeQuiz);
        tv_quizScore = itemView.findViewById(R.id.tv_quizScore);
        db_quizScore = itemView.findViewById(R.id.db_quizScore);
        img_optionsMenu = itemView.findViewById(R.id.img_optionsMenu);
            }

}
