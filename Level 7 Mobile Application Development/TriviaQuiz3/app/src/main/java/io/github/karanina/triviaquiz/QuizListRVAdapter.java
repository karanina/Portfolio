package io.github.karanina.triviaquiz;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.util.Log;
import android.view.InflateException;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.widget.PopupMenu;
import androidx.recyclerview.widget.RecyclerView;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import io.github.karanina.triviaquiz.model.Quiz;

public class QuizListRVAdapter extends RecyclerView.Adapter<QuizListRVHolder> {
    ArrayList<Quiz> quizList;
    Context context;
    String userID;
    String accessLevel;
    Date currentDate;
    SimpleDateFormat dateFormat;

    public QuizListRVAdapter(Context context, String userID, String accessLevel, Date currentDate, SimpleDateFormat dateFormat) {
        this.context = context;
        this.userID = userID;
        this.accessLevel = accessLevel;
        this.currentDate = currentDate;
        this.dateFormat = dateFormat;
    }

    @NonNull
    @Override
    public QuizListRVHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater layoutInflater = LayoutInflater.from(context);
        View view = layoutInflater.inflate(R.layout.activity_quiz_list_row, parent, false);
        return new QuizListRVHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull QuizListRVHolder holder, int position) {
        Quiz quiz = quizList.get(position);
        holder.db_quizName.setText(quiz.getName());
        holder.db_startDate.setText(quiz.getStartDate());
        holder.db_endDate.setText(quiz.getEndDate());
        holder.db_difficulty.setText(quiz.getDifficulty());
        holder.db_category.setText(quiz.getCategory());

        if (accessLevel.equals("Admin")) {
            holder.img_optionsMenu.setVisibility(View.VISIBLE);
            holder.img_optionsMenu.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Log.d("ONCLICK", "onclick " + quiz.toString());
                    try {
                        PopupMenu optionsMenu = new PopupMenu(view.getContext(), view);
                        optionsMenu.inflate(R.menu.quiz_list_row_menu);
                        optionsMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                            @Override
                            public boolean onMenuItemClick(MenuItem item) {
                                switch (item.getItemId()) {
                                    case R.id.menu_updateQuiz:
                                        Log.d("MENU_CLICK", "update clicked");
                                        Intent intent = new Intent();
                                        intent.putExtra("userID", userID);
                                        intent.putExtra("accessLevel", accessLevel);
                                        intent.putExtra("quizKey", quiz.getKey());
                                        intent.setClass(context, UpdateQuiz.class);
                                        context.startActivity(intent);
                                        return true;

                                    case R.id.menu_deleteQuiz:
                                        Log.d("MENU_CLICK", "delete clicked");
                                        createDeleteDialog(quiz, holder.getAdapterPosition());
                                        return true;
                                    default:
                                        return false;
                                }

                            }
                        });
                        optionsMenu.show();
                    } catch (InflateException e) {
                        e.toString();
                        e.printStackTrace();
                    }
                }
            });
        }


        if (quiz.getScore() != null) {
            holder.tv_quizScore.setVisibility(View.VISIBLE);
            String quizScore = quiz.getScore() + "/10";
            holder.db_quizScore.setText(quizScore);
            holder.db_quizScore.setVisibility(View.VISIBLE);
            holder.btn_takeQuiz.setVisibility(View.GONE);
        }
        try {
            if (quiz.getEndDate() != null && quiz.getStartDate() != null) {
                if (currentDate.before(dateFormat.parse(quiz.getEndDate())) || currentDate.equals(dateFormat.parse(quiz.getEndDate()))) {
                    if (currentDate.after(dateFormat.parse(quiz.getStartDate())) || currentDate.equals(dateFormat.parse(quiz.getStartDate()))) {
                        if (quiz.getScore() == null) {
                            setTakeQuizButton(quiz, holder);
                        } else {
                            holder.btn_takeQuiz.setVisibility(View.GONE);
                        }
                    } else {
                        holder.btn_takeQuiz.setVisibility(View.GONE);
                    }
                } else {
                    holder.btn_takeQuiz.setVisibility(View.GONE);
                }
            }
        } catch (ParseException e) {
            e.printStackTrace();
            holder.btn_takeQuiz.setVisibility(View.GONE);
        }
    }

    private void createDeleteDialog(Quiz quiz, int position) {
        AlertDialog.Builder builder;
        builder = new AlertDialog.Builder(context);
        builder.setMessage("Are you sure you want to delete " + quiz.getName() + "?");
        builder.setTitle("Delete Quiz");
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                quizList.remove(quiz);
                notifyItemRemoved(position);
                QuizDAO quizDAO = new QuizDAO();
                quizDAO.delete(quiz.getKey()).addOnSuccessListener(success -> {
                            Toast.makeText(context, quiz.getName() + " has been deleted.", Toast.LENGTH_SHORT).show();
                        })
                        .addOnFailureListener(fail -> {
                            Toast.makeText(context,
                                    fail.getMessage(), Toast.LENGTH_SHORT).show();
                        });
            }
        });
        builder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Toast.makeText(context, quiz.getName() + " has not been deleted.", Toast.LENGTH_SHORT).show();
            }
        });

        AlertDialog alertDialog = builder.create();
        alertDialog.show();
    }

    private void setTakeQuizButton(Quiz quiz, QuizListRVHolder holder) {
        holder.btn_takeQuiz.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(context, TakeQuiz.class);
                intent.putExtra("quizKey", quiz.getKey());
                intent.putExtra("accessLevel", accessLevel);
                intent.putExtra("userID", userID);
                intent.putExtra("questionsAnswered", 0);
                intent.putExtra("questionsCorrect", 0);
                intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                context.startActivity(intent);
            }
        });
    }

    @Override
    public int getItemCount() {
        if (quizList != null) {
            return quizList.size();
        } else {
            return 0;
        }
    }

    public void setItems(ArrayList<Quiz> quizzes) {
        this.quizList = quizzes;
        notifyDataSetChanged();
    }
}
